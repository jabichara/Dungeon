using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Structures
{

    public class HashTable
    {
        private readonly byte _maxSize = 255;
        private readonly Dictionary<int, List<Item>> _items = null;
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => _items?.ToList()?.AsReadOnly();
        public HashTable()
        {
            _items = new Dictionary<int, List<Item>>(_maxSize);
        }
        public void Insert(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            var item = new Item(key, value);
            var hash = GetHash(item.Key);
            List<Item> hashTableItem = null;
            if (_items.ContainsKey(hash))
            {
                hashTableItem = _items[hash];
                var oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);
                if (oldElementWithKey != null)
                {
                    throw new ArgumentException($"Хеш-таблица уже содержит элемент с ключом {key}. Ключ должен быть уникален.", nameof(key));
                }
                _items[hash].Add(item);
            }
            else
            {
                hashTableItem = new List<Item> { item };
                _items.Add(hash, hashTableItem);
            }
        }
        public void Delete(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
            }
            var hash = GetHash(key);
            if (!_items.ContainsKey(hash))
            {
                return;
            }
            var hashTableItem = _items[hash];
            var item = hashTableItem.SingleOrDefault(i => i.Key == key);
            if (item != null)
            {
                hashTableItem.Remove(item);
            }
        }
        public string Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key));
            }
            var hash = GetHash(key);
            if (!_items.ContainsKey(hash))
            {
                return null;
            }
            var hashTableItem = _items[hash];
            if (hashTableItem != null)
            {
                var item = hashTableItem.SingleOrDefault(i => i.Key == key);
                if (item != null)
                {
                    return item.Value;
                }
            }
            return null;
        }
        private int GetHash(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length > _maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(value));
            }
            var hash = value.Length;
            return hash;
        }
    }

    public class Item
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public Item(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            Key = key;
            Value = value;
        }
        public override string ToString()
        {
            return Key;
        }
    }
}
