using CourseWork.BusinessLogic.ServiceResults;
using CourseWork.BusinessLogic.Services;
using CourseWork.Core;
using CourseWork.Core.AdditionalFields;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.StaticServices
{
    public sealed class ItemFieldsService : object
    {
        private readonly IService<BooleanField> _booleanFieldService;
        private readonly IService<DateField> _dateFieldService;
        private readonly IService<IntField> _intFieldService;
        private readonly IService<StringField> _stringFieldService;
        private readonly IService<TextField> _textFieldService;

        public ItemFieldsService(IService<BooleanField> booleanFieldService,
            IService<DateField> dateFieldService,
            IService<IntField> intFieldService,
            IService<StringField> stringFieldService,
            IService<TextField> textFieldService)
        {
            _booleanFieldService = booleanFieldService;
            _dateFieldService = dateFieldService;
            _intFieldService = intFieldService;
            _stringFieldService = stringFieldService;
            _textFieldService = textFieldService;
        }

        public async Task<ServiceResult<IEnumerable<IAdditionalField>>> GetItemFields(int itemId)
        {
            ServiceResult<IEnumerable<IAdditionalField>> res =
                new ServiceResult<IEnumerable<IAdditionalField>>();

            var booleans = await GetItemBooleanFields(itemId);
            var dates = await GetItemDateFields(itemId);
            var ints = await GetItemIntFields(itemId);
            var strings = await GetItemStringFields(itemId);
            var texts = await GetItemTextFields(itemId);

            if (booleans.Successfully
                && dates.Successfully
                && ints.Successfully
                && strings.Successfully
                && texts.Successfully)
            {
                List<IAdditionalField> fields = new List<IAdditionalField>();
                fields.AddRange(booleans.Value);
                fields.AddRange(dates.Value);
                fields.AddRange(ints.Value);
                fields.AddRange(strings.Value);
                fields.AddRange(texts.Value);
                res.Value = fields;
            }
            else
            {
                res.Successfully = false;
                res.Errors.AddRange(booleans.Errors);
                res.Errors.AddRange(dates.Errors);
                res.Errors.AddRange(ints.Errors);
                res.Errors.AddRange(strings.Errors);
                res.Errors.AddRange(texts.Errors);
            }

            return res;
        }

        private async Task<ServiceResult<IEnumerable<BooleanField>>> GetItemBooleanFields(int itemId)
        {
            var res = new ServiceResult<IEnumerable<BooleanField>>();
            var serviceRes = await _booleanFieldService.SelectAsync();
            if (res.Successfully)
            {
                res.Value = serviceRes.Value.Where(v => v.CollectionItemId == itemId);
            }
            else
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError("Boolean fields failed to add"));
            }

            return res;
        }

        private async Task<ServiceResult<IEnumerable<DateField>>> GetItemDateFields(int itemId)
        {
            var res = new ServiceResult<IEnumerable<DateField>>();
            var serviceRes = await _dateFieldService.SelectAsync();
            if (res.Successfully)
            {
                res.Value = serviceRes.Value.Where(v => v.CollectionItemId == itemId);
            }
            else
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError("Date fields failed to add"));
            }

            return res;
        }

        private async Task<ServiceResult<IEnumerable<IntField>>> GetItemIntFields(int itemId)
        {
            var res = new ServiceResult<IEnumerable<IntField>>();
            var serviceRes = await _intFieldService.SelectAsync();
            if (res.Successfully)
            {
                res.Value = serviceRes.Value.Where(v => v.CollectionItemId == itemId);
            }
            else
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError("Int fields failed to add"));
            }

            return res;
        }

        private async Task<ServiceResult<IEnumerable<StringField>>> GetItemStringFields(int itemId)
        {
            var res = new ServiceResult<IEnumerable<StringField>>();
            var serviceRes = await _stringFieldService.SelectAsync();
            if (res.Successfully)
            {
                res.Value = serviceRes.Value.Where(v => v.CollectionItemId == itemId);
            }
            else
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError("String fields failed to add"));
            }

            return res;
        }

        private async Task<ServiceResult<IEnumerable<TextField>>> GetItemTextFields(int itemId)
        {
            var res = new ServiceResult<IEnumerable<TextField>>();
            var serviceRes = await _textFieldService.SelectAsync();
            if (res.Successfully)
            {
                res.Value = serviceRes.Value.Where(v => v.CollectionItemId == itemId);
            }
            else
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError("Text fields failed to add"));
            }

            return res;
        }

        public async Task<ServiceResult> AddField(int itemId, IAdditionalField field)
        {
            if (field is BooleanField)
                return await AddBooleanField(itemId, field as BooleanField);
            if (field is DateField)
                return await AddDateField(itemId, field as DateField);
            if (field is IntField)
                return await AddIntField(itemId, field as IntField);
            if (field is StringField)
                return await AddStringField(itemId, field as StringField);
            if (field is TextField)
                return await AddTextField(itemId, field as TextField);

            return new ServiceResult
            {
                Successfully = false,
                Errors = new List<ServiceError>
                {
                    new ServiceError("Input field is not supported"),
                },
            };
        }

        public async Task<ServiceResult> AddFields(int itemId, IEnumerable<IAdditionalField> fields)
        {
            ServiceResult res = new ServiceResult();
            foreach (var field in fields)
            {
                var serviceRes = await AddField(itemId, field);
                if (!serviceRes.Successfully)
                {
                    res.Successfully = false;
                    res.Errors.AddRange(serviceRes.Errors);
                }
            }

            return res;
        }

        private async Task<ServiceResult> AddBooleanField(int itemId, BooleanField field)
        {
            field.CollectionItemId = itemId;
            return await _booleanFieldService.InsertAsync(field);
        }

        private async Task<ServiceResult> AddDateField(int itemId, DateField field)
        {
            field.CollectionItemId = itemId;
            return await _dateFieldService.InsertAsync(field);
        }

        private async Task<ServiceResult> AddIntField(int itemId, IntField field)
        {
            field.CollectionItemId = itemId;
            return await _intFieldService.InsertAsync(field);
        }

        private async Task<ServiceResult> AddStringField(int itemId, StringField field)
        {
            field.CollectionItemId = itemId;
            return await _stringFieldService.InsertAsync(field);
        }

        private async Task<ServiceResult> AddTextField(int itemId, TextField field)
        {
            field.CollectionItemId = itemId;
            return await _textFieldService.InsertAsync(field);
        }

        public async Task<ServiceResult> UpdateField(IAdditionalField field)
        {
            if (field is BooleanField)
                return await UpdateBooleanField(field as BooleanField);
            if (field is DateField)
                return await UpdateDateField(field as DateField);
            if (field is IntField)
                return await UpdateIntField(field as IntField);
            if (field is StringField)
                return await UpdateStringField(field as StringField);
            if (field is TextField)
                return await UpdateTextField(field as TextField);

            return new ServiceResult
            {
                Successfully = false,
                Errors = new List<ServiceError>
                {
                    new ServiceError("Input field is not supported"),
                },
            };
        }

        public async Task<ServiceResult> UpdateFields(IEnumerable<IAdditionalField> fields)
        {
            ServiceResult res = new ServiceResult();
            foreach (var field in fields)
            {
                var serviceRes = await UpdateField(field);
                if (!serviceRes.Successfully)
                {
                    res.Successfully = false;
                    res.Errors.AddRange(serviceRes.Errors);
                }
            }

            return res;
        }

        private async Task<ServiceResult> UpdateBooleanField(BooleanField field)
            => await _booleanFieldService.UpdateAsync(field);

        private async Task<ServiceResult> UpdateDateField(DateField field)
            => await _dateFieldService.UpdateAsync(field);

        private async Task<ServiceResult> UpdateIntField(IntField field)
            => await _intFieldService.UpdateAsync(field);

        private async Task<ServiceResult> UpdateStringField(StringField field)
            => await _stringFieldService.UpdateAsync(field);

        private async Task<ServiceResult> UpdateTextField(TextField field)
            => await _textFieldService.UpdateAsync(field);

        public async Task<ServiceResult> DeleteField(IAdditionalField field)
        {
            if (field is BooleanField)
                return await DeleteBooleanField(field as BooleanField);
            if (field is DateField)
                return await DeleteDateField(field as DateField);
            if (field is IntField)
                return await DeleteIntField(field as IntField);
            if (field is StringField)
                return await DeleteStringField(field as StringField);
            if (field is TextField)
                return await DeleteTextField(field as TextField);

            return new ServiceResult
            {
                Successfully = false,
                Errors = new List<ServiceError>
                {
                    new ServiceError("Input field is not supported"),
                },
            };
        }

        public async Task<ServiceResult> DeleteFields(IEnumerable<IAdditionalField> fields)
        {
            ServiceResult res = new ServiceResult();
            foreach (var field in fields)
            {
                var serviceRes = await DeleteField(field);
                if (!serviceRes.Successfully)
                {
                    res.Successfully = false;
                    res.Errors.AddRange(serviceRes.Errors);
                }
            }

            return res;
        }

        public async Task<ServiceResult> DeleteFields(int itemId)
        {
            ServiceResult res = new ServiceResult();
            var fields = await GetItemFields(itemId);
            if (fields.Successfully)
            {
                var serviceRes = await DeleteFields(fields.Value);
                if (!serviceRes.Successfully)
                {
                    res.Successfully = false;
                    res.Errors.AddRange(serviceRes.Errors);
                }
            }
            else
            {
                res.Successfully = false;
                res.Errors.Add(new ServiceError("Cannot delete item fields"));
            }

            return res;
        }

        private async Task<ServiceResult> DeleteBooleanField(BooleanField field)
            => await _booleanFieldService.DeleteAsync(field);

        private async Task<ServiceResult> DeleteDateField(DateField field)
            => await _dateFieldService.DeleteAsync(field);

        private async Task<ServiceResult> DeleteIntField(IntField field)
            => await _intFieldService.DeleteAsync(field);

        private async Task<ServiceResult> DeleteStringField(StringField field)
            => await _stringFieldService.DeleteAsync(field);

        private async Task<ServiceResult> DeleteTextField(TextField field)
            => await _textFieldService.DeleteAsync(field);

        public async Task<ServiceResult<IEnumerable<BooleanField>>> GetBooleanFields()
            => await _booleanFieldService.SelectAsync();

        public async Task<ServiceResult<IEnumerable<DateField>>> GetDateFields()
            => await _dateFieldService.SelectAsync();

        public async Task<ServiceResult<IEnumerable<IntField>>> GetIntFields()
            => await _intFieldService.SelectAsync();

        public async Task<ServiceResult<IEnumerable<StringField>>> GetStringFields()
            => await _stringFieldService.SelectAsync();

        public async Task<ServiceResult<IEnumerable<TextField>>> GetTextFields()
            => await _textFieldService.SelectAsync();
    }
}
