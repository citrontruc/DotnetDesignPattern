# CustomDict

A program to implement a simple dictionary in dotnet using arrays.

## Description

In order to implement our dictionaries, we store values using linked lists.

The couple Key: Value is stored in the linkedList located at position n with n = hashCode of the Key modulo size of our array of linkedList.

Whenever we try to access a value, we start by checking at which chain of linkedlist it belongs by looking the value of the hashCode modulo the size of our array of linkedlist. We then look in the corresponding linked list for our value.

When we have too many values (decided by a threshold), we resize our array of linkedlists and replace all our values in their new linkedList.

## Content

- CustomDict: the project containing our implementation of the CustomDictionary as well as the implementation of a LinkedList.
- CustomDict.Tests: tests to evaluate the behaviour of our components.

## Available methods

The CustomDict Class supports the following methods / behaviors:

- Indexing to set new values and get existing values.
- GetKeys() to get all the keys in our dictionaries.
- GetValues() to get all the values in our dictionaries
- Add(TKey key, TValue value) to add a new value to our dictionary or change the value of an existing key.
- TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue? value) to check if a key exists and retrieve its value if it exists.
- ContainsKey(TKey key) to check if a key exists in our dictionary.
- FindKeysCorrespondingToValue(TValue value) to find all keys corresponding to a given value.
- RemoveKey(TKey key) Remove a key and its associated value to our CustomDictionary.
- TrimExcess() to try and compress our dictionary and make it smaller in memory.
- ToString() to get a string representation of our dictionary.

Have a great day :smiley:
