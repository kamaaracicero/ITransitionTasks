using CourseWork.BusinessLogic.ServiceResults;
using CourseWork.BusinessLogic.Services;
using CourseWork.Core;
using CourseWork.Core.AdditionalFields;
using CourseWork.Core.UsersActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.StaticServices
{
    public sealed class SearchItemService : object
    {
        private readonly IService<CollectionItem> _itemService;
        private readonly IService<UserComment> _commentService;
        private readonly IService<StringField> _stringFieldService;
        private readonly IService<TextField> _textFieldService;

        public SearchItemService(IService<CollectionItem> itemService,
            IService<UserComment> commentService,
            IService<StringField> stringFieldService,
            IService<TextField> textFieldService)
        {
            _itemService = itemService;
            _commentService = commentService;
            _stringFieldService = stringFieldService;
            _textFieldService = textFieldService;
        }

        public async Task<ServiceResult<IEnumerable<CollectionItem>>> SearchItems(string searchString)
        {
            List<int> items = new List<int>();

            var commentsRes = await SearchInComments(searchString, items);
            if (commentsRes.Successfully)
                items.AddRange(commentsRes.Value);

            var stringsRes = await SearchInStringFields(searchString, items);
            if (stringsRes.Successfully)
                items.AddRange(stringsRes.Value);

            var textRes = await SearchInTextFields(searchString, items);
            if (textRes.Successfully)
                items.AddRange(textRes.Value);

            ServiceResult<IEnumerable<CollectionItem>> res = new ServiceResult<IEnumerable<CollectionItem>>();
            if (!commentsRes.Successfully || !stringsRes.Successfully || !textRes.Successfully)
            {
                res.Successfully = false;
                res.Errors.AddRange(commentsRes.Errors);
                res.Errors.AddRange(stringsRes.Errors);
                res.Errors.AddRange(textRes.Errors);
            }

            res.Value = (await _itemService.SelectAsync()).Value.Where(i => items.Contains(i.Id));
            return res;
        }

        private async Task<ServiceResult<IEnumerable<int>>> SearchInComments(string searchString,
            IEnumerable<int> foundItems)
        {
            var serviceRes = await _commentService.SelectAsync();
            if (!serviceRes.Successfully)
            {
                return new ServiceResult<IEnumerable<int>>
                {
                    Successfully = false,
                    Errors = serviceRes.Errors,
                };
            }
            else
            {
                var ids = serviceRes.Value
                    .Where(c => c.Text.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .Select(c => c.CollectionItemId)
                    .Except(foundItems);
                return new ServiceResult<IEnumerable<int>>
                {
                    Value = ids,
                };
            }
        }

        private async Task<ServiceResult<IEnumerable<int>>> SearchInStringFields(string searchString,
            IEnumerable<int> foundItems)
        {
            var serviceRes = await _stringFieldService.SelectAsync();
            if (!serviceRes.Successfully)
            {
                return new ServiceResult<IEnumerable<int>>
                {
                    Successfully = false,
                    Errors = serviceRes.Errors,
                };
            }
            else
            {
                var ids = serviceRes.Value
                    .Where(c => c.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .Select(c => c.CollectionItemId)
                    .Except(foundItems);
                return new ServiceResult<IEnumerable<int>>
                {
                    Value = ids,
                };
            }
        }

        private async Task<ServiceResult<IEnumerable<int>>> SearchInTextFields(string searchString,
            IEnumerable<int> foundItems)
        {
            var serviceRes = await _textFieldService.SelectAsync();
            if (!serviceRes.Successfully)
            {
                return new ServiceResult<IEnumerable<int>>
                {
                    Successfully = false,
                    Errors = serviceRes.Errors,
                };
            }
            else
            {
                var ids = serviceRes.Value
                    .Where(c => c.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .Select(c => c.CollectionItemId)
                    .Except(foundItems);
                return new ServiceResult<IEnumerable<int>>
                {
                    Value = ids,
                };
            }
        }
    }
}
