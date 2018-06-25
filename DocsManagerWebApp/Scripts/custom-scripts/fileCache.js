angular.module('upload-progressbar-module', ['angular-cache'])
    .config(function (CacheFactoryProvider) {
        angular.extend(CacheFactoryProvider.defaults, { maxAge: 60 * 60 * 1000 });// 1 hour
    });
angular.module('upload-progressbar-module').service('fileCache',
        function (CacheFactory) {
            var itemsWithFileCache;

            if (!CacheFactory.get('itemsWithFileCache')) {
                itemsWithFileCache = CacheFactory('itemsWithFileCache', {
                    maxAge: 60 * 60 * 1000,
                    deleteOnExpire: 'aggressive'
            });
            }

            var api = {};
            var self = this;
            self.sliceKey = null;
            api.setSliceKey = function (sliceKey) {
                self.sliceKey = sliceKey;
            };

            api.get = function (key) {
                var items = itemsWithFileCache.get(key);
                if (!items) {
                    items = [];
                    itemsWithFileCache.put(key, items);
                }
                return items;
            }

            api.set = function (key, files) {
                itemsWithFileCache.put(key, files);
            }

            api.remove = function (key) {
                itemsWithFileCache.put(key, []);
            }
            api.removeForSlice = function (sliceKey, arrayIds) {
                arrayIds.forEach(function(id) {
                    itemsWithFileCache.put(sliceKey + id, []);
                });
            }
            return api;

           
        }

);