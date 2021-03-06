﻿/* Copyright 2010-2011 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using MongoDB.Bson.IO;

namespace MongoDB.Bson {
    /// <summary>
    /// Represents a BSON array.
    /// </summary>
    [Serializable]
    public class BsonArray : BsonValue, IComparable<BsonArray>, IEquatable<BsonArray>, IList<BsonValue> {
        #region private fields
        private List<BsonValue> values = new List<BsonValue>();
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        public BsonArray()
            : base(BsonType.Array) {
        }

        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        public BsonArray(
            IEnumerable<bool> values
        )
            : base(BsonType.Array) {
            AddRange(values);
        }

        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        public BsonArray(
            IEnumerable<BsonValue> values
        )
            : base(BsonType.Array) {
            AddRange(values);
        }

        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        public BsonArray(
            IEnumerable<DateTime> values
        )
            : base(BsonType.Array) {
            AddRange(values);
        }

        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        public BsonArray(
            IEnumerable<double> values
        )
            : base(BsonType.Array) {
            AddRange(values);
        }

        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        public BsonArray(
            IEnumerable<int> values
        )
            : base(BsonType.Array) {
            AddRange(values);
        }

        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        public BsonArray(
            IEnumerable<long> values
        )
            : base(BsonType.Array) {
            AddRange(values);
        }

        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        public BsonArray(
            IEnumerable<object> values
        )
            : base(BsonType.Array) {
            AddRange(values);
        }

        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        public BsonArray(
            IEnumerable<ObjectId> values
        )
            : base(BsonType.Array) {
            AddRange(values);
        }

        /// <summary>
        /// Initializes a new instance of the BsonArray class.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        public BsonArray(
            IEnumerable<string> values
        )
            : base(BsonType.Array) {
            AddRange(values);
        }
        #endregion

        #region public properties
        /// <summary>
        /// Gets the count of array elements.
        /// </summary>
        public int Count {
            get { return values.Count; }
        }

        /// <summary>
        /// Gets whether the array is read-only.
        /// </summary>
        public bool IsReadOnly {
            get { return false; }
        }

        /// <summary>
        /// Gets the array elements as raw values (see BsonValue.RawValue).
        /// </summary>
        public IEnumerable<object> RawValues {
            get { return values.Select(v => v.RawValue); }
        }

        /// <summary>
        /// Gets the array elements.
        /// </summary>
        public IEnumerable<BsonValue> Values {
            get { return values; }
        }
        #endregion

        #region public indexers
        /// <summary>
        /// Gets or sets an array element.
        /// </summary>
        /// <param name="index">The zero based index of the element.</param>
        /// <returns>The value of the element.</returns>
        public BsonValue this[
            int index
        ] {
            get { return values[index]; }
            set { values[index] = value; }
        }
        #endregion

        #region public static methods
        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>A BsonArray or null.</returns>
        public static BsonArray Create(
            IEnumerable<bool> values
        ) {
            if (values != null) {
                return new BsonArray(values);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>A BsonArray or null.</returns>
        public static BsonArray Create(
            IEnumerable<BsonValue> values
        ) {
            if (values != null) {
                return new BsonArray(values);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>A BsonArray or null.</returns>
        public static BsonArray Create(
            IEnumerable<DateTime> values
        ) {
            if (values != null) {
                return new BsonArray(values);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>A BsonArray or null.</returns>
        public static BsonArray Create(
            IEnumerable<double> values
        ) {
            if (values != null) {
                return new BsonArray(values);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>A BsonArray or null.</returns>
        public static BsonArray Create(
            IEnumerable<int> values
        ) {
            if (values != null) {
                return new BsonArray(values);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>A BsonArray or null.</returns>
        public static BsonArray Create(
            IEnumerable<long> values
        ) {
            if (values != null) {
                return new BsonArray(values);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>A BsonArray or null.</returns>
        public static BsonArray Create(
            IEnumerable<object> values
        ) {
            if (values != null) {
                return new BsonArray(values);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>A BsonArray or null.</returns>
        public static BsonArray Create(
            IEnumerable<ObjectId> values
        ) {
            if (values != null) {
                return new BsonArray(values);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>A BsonArray or null.</returns>
        public static BsonArray Create(
            IEnumerable<string> values
        ) {
            if (values != null) {
                return new BsonArray(values);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Creates a new BsonArray.
        /// </summary>
        /// <param name="value">A value to be mapped to a BsonArray.</param>
        /// <returns>A BsonArray or null.</returns>
        public new static BsonArray Create(
            object value
        ) {
            if (value != null) {
                return (BsonArray) BsonTypeMapper.MapToBsonValue(value, BsonType.Array);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Reads a BsonArray from a BsonReader.
        /// </summary>
        /// <param name="bsonReader">The reader.</param>
        /// <returns>A BsonArray.</returns>
        public static new BsonArray ReadFrom(
            BsonReader bsonReader
        ) {
            var array = new BsonArray();
            bsonReader.ReadStartArray();
            while (bsonReader.ReadBsonType() != BsonType.EndOfDocument) {
                var value = BsonValue.ReadFrom(bsonReader);
                array.Add(value);
            }
            bsonReader.ReadEndArray();
            return array;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Adds an element to the array.
        /// </summary>
        /// <param name="value">The value to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray Add(
            BsonValue value
        ) {
            if (value != null) {
                values.Add(value);
            }
            return this;
        }

        /// <summary>
        /// Adds multiple elements to the array.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray AddRange(
            IEnumerable<bool> values
        ) {
            if (values != null) {
                foreach (var value in values) {
                    this.values.Add(BsonBoolean.Create(value));
                }
            }
            return this;
        }

        /// <summary>
        /// Adds multiple elements to the array.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray AddRange(
            IEnumerable<BsonValue> values
        ) {
            if (values != null) {
                this.values.AddRange(values);
            }
            return this;
        }

        /// <summary>
        /// Adds multiple elements to the array.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray AddRange(
            IEnumerable<DateTime> values
        ) {
            if (values != null) {
                foreach (var value in values) {
                    this.values.Add(BsonDateTime.Create(value));
                }
            }
            return this;
        }

        /// <summary>
        /// Adds multiple elements to the array.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray AddRange(
            IEnumerable<double> values
        ) {
            if (values != null) {
                foreach (var value in values) {
                    this.values.Add(BsonDouble.Create(value));
                }
            }
            return this;
        }

        /// <summary>
        /// Adds multiple elements to the array.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray AddRange(
            IEnumerable<int> values
        ) {
            if (values != null) {
                foreach (var value in values) {
                    this.values.Add(BsonInt32.Create(value));
                }
            }
            return this;
        }

        /// <summary>
        /// Adds multiple elements to the array.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray AddRange(
            IEnumerable<long> values
        ) {
            if (values != null) {
                foreach (var value in values) {
                    this.values.Add(BsonInt64.Create(value));
                }
            }
            return this;
        }

        /// <summary>
        /// Adds multiple elements to the array.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray AddRange(
            IEnumerable<object> values
        ) {
            if (values != null) {
                foreach (var value in values) {
                    this.values.Add(BsonValue.Create(value));
                }
            }
            return this;
        }

        /// <summary>
        /// Adds multiple elements to the array.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray AddRange(
            IEnumerable<ObjectId> values
        ) {
            if (values != null) {
                foreach (var value in values) {
                    this.values.Add(BsonObjectId.Create(value));
                }
            }
            return this;
        }

        /// <summary>
        /// Adds multiple elements to the array.
        /// </summary>
        /// <param name="values">A list of values to add to the array.</param>
        /// <returns>The array (so method calls can be chained).</returns>
        public BsonArray AddRange(
            IEnumerable<string> values
        ) {
            if (values != null) {
                foreach (var value in values) {
                    this.values.Add(BsonString.Create(value));
                }
            }
            return this;
        }

        /// <summary>
        /// Creates a shallow clone of the array (see also DeepClone).
        /// </summary>
        /// <returns>A shallow clone of the array.</returns>
        public override BsonValue Clone() {
            BsonArray clone = new BsonArray();
            foreach (var value in values) {
                clone.Add(value.Clone());
            }
            return clone;
        }

        /// <summary>
        /// Clears the array.
        /// </summary>
        public void Clear() {
            values.Clear();
        }

        /// <summary>
        /// Compares the array to another array.
        /// </summary>
        /// <param name="other">The other array.</param>
        /// <returns>A 32-bit signed integer that indicates whether this array is less than, equal to, or greather than the other.</returns>
        public int CompareTo(
            BsonArray other
        ) {
            if (other == null) { return 1; }
            for (int i = 0; i < values.Count && i < other.values.Count; i++) {
                int r = values[i].CompareTo(other.values[i]);
                if (r != 0) { return r; }
            }
            return values.Count.CompareTo(other.values.Count);
        }

        /// <summary>
        /// Compares the array to another BsonValue.
        /// </summary>
        /// <param name="other">The other BsonValue.</param>
        /// <returns>A 32-bit signed integer that indicates whether this array is less than, equal to, or greather than the other BsonValue.</returns>
        public override int CompareTo(
            BsonValue other
        ) {
            if (other == null) { return 1; }
            var otherArray = other as BsonArray;
            if (otherArray != null) {
                return CompareTo(otherArray);
            }
            return CompareTypeTo(other);
        }

        /// <summary>
        /// Tests whether the array contains a value.
        /// </summary>
        /// <param name="value">The value to test for.</param>
        /// <returns>True if the array contains the value.</returns>
        public bool Contains(
            BsonValue value
        ) {
            return values.Contains(value);
        }

        /// <summary>
        /// Copies elements from this array to another array.
        /// </summary>
        /// <param name="array">The other array.</param>
        /// <param name="arrayIndex">The zero based index of the other array at which to start copying.</param>
        public void CopyTo(
            BsonValue[] array,
            int arrayIndex
        ) {
            for (int i = 0, j = arrayIndex; i < values.Count; i++, j++) {
                array[j] = values[i];
            }
        }

        /// <summary>
        /// Copies elements from this array to another array as raw values (see BsonValue.RawValue).
        /// </summary>
        /// <param name="array">The other array.</param>
        /// <param name="arrayIndex">The zero based index of the other array at which to start copying.</param>
        public void CopyTo(
            object[] array,
            int arrayIndex
        ) {
            for (int i = 0, j = arrayIndex; i < values.Count; i++, j++) {
                array[j] = values[i].RawValue;
            }
        }

        /// <summary>
        /// Creates a deep clone of the array (see also Clone).
        /// </summary>
        /// <returns>A deep clone of the array.</returns>
        public override BsonValue DeepClone() {
            BsonArray clone = new BsonArray();
            foreach (var value in values) {
                clone.Add(value.DeepClone());
            }
            return clone;
        }

        /// <summary>
        /// Compares this array to another array.
        /// </summary>
        /// <param name="rhs">The other array.</param>
        /// <returns>True if the two arrays are equal.</returns>
        public bool Equals(
            BsonArray rhs
        ) {
            if (rhs == null) { return false; }
            return object.ReferenceEquals(this, rhs) || this.values.SequenceEqual(rhs.values);
        }

        /// <summary>
        /// Compares this BsonArray to another object.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True if the other object is a BsonArray and equal to this one.</returns>
        public override bool Equals(
            object obj
        ) {
            return Equals(obj as BsonArray); // works even if obj is null
        }

        /// <summary>
        /// Gets an enumerator that can enumerate the elements of the array.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator<BsonValue> GetEnumerator() {
            return values.GetEnumerator();
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() {
            // see Effective Java by Joshua Bloch
            int hash = 17;
            hash = 37 * hash + bsonType.GetHashCode();
            foreach (var value in values) {
                hash = 37 * hash + value.GetHashCode();
            }
            return hash;
        }

        /// <summary>
        /// Gets the index of a value in the array.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The zero based index of the value (or -1 if not found).</returns>
        public int IndexOf(
            BsonValue value
        ) {
            return values.IndexOf(value);
        }

        /// <summary>
        /// Gets the index of a value in the array.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <param name="index">The zero based index at which to start the search.</param>
        /// <returns>The zero based index of the value (or -1 if not found).</returns>
        public int IndexOf(
            BsonValue value,
            int index
        ) {
            return values.IndexOf(value, index);
        }

        /// <summary>
        /// Gets the index of a value in the array.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <param name="index">The zero based index at which to start the search.</param>
        /// <param name="count">The number of elements to search.</param>
        /// <returns>The zero based index of the value (or -1 if not found).</returns>
        public int IndexOf(
            BsonValue value,
            int index,
            int count
        ) {
            return values.IndexOf(value, index, count);
        }

        /// <summary>
        /// Inserts a new value into the array.
        /// </summary>
        /// <param name="index">The zero based index at which to insert the new value.</param>
        /// <param name="value">The new value.</param>
        public void Insert(
            int index,
            BsonValue value
        ) {
            values.Insert(index, value);
        }

        /// <summary>
        /// Removes the first occurrence of a value from the array.
        /// </summary>
        /// <param name="value">The value to remove.</param>
        /// <returns>True if the value was removed.</returns>
        public bool Remove(
            BsonValue value
        ) {
            return values.Remove(value);
        }

        /// <summary>
        /// Removes an element from the array.
        /// </summary>
        /// <param name="index">The zero based index of the element to remove.</param>
        public void RemoveAt(
            int index
        ) {
            values.RemoveAt(index);
        }

        /// <summary>
        /// Converts the BsonArray to an array of BsonValues.
        /// </summary>
        /// <returns>An array of BsonValues.</returns>
        public BsonValue[] ToArray() {
            return values.ToArray();
        }

        /// <summary>
        /// Converts the BsonArray to a list of BsonValues.
        /// </summary>
        /// <returns>A list of BsonValues.</returns>
        public List<BsonValue> ToList() {
            return values.ToList();
        }

        /// <summary>
        /// Returns a string representation of the array.
        /// </summary>
        /// <returns>A string representation of the array.</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < values.Count; i++) {
                if (i > 0) { sb.Append(", "); }
                sb.Append(values[i].ToString());
            }
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// Writes the array to a BsonWriter.
        /// </summary>
        /// <param name="bsonWriter">The writer.</param>
        public new void WriteTo(
            BsonWriter bsonWriter
        ) {
            bsonWriter.WriteStartArray();
            for (int i = 0; i < values.Count; i++) {
                values[i].WriteTo(bsonWriter);
            }
            bsonWriter.WriteEndArray();
        }
        #endregion

        #region private methods
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion

        #region explicit interface implementations
        // our version of Add returns BsonArray
        void ICollection<BsonValue>.Add(
            BsonValue value
        ) {
            Add(value);
        }
        #endregion
    }
}
