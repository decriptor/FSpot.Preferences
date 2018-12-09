using FSpot.Preferences;

using NUnit.Framework;

using Shouldly;

namespace FSpot.Preferences.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanCreateDictionaryPreferencesStore()
        {
            var store = new MemoryPreferenceStore();
            store.ShouldNotBeNull();
        }

        [Test]
        public void NewPreferenceStoreIsEmpty()
        {
            var store = new MemoryPreferenceStore();
            store.Count.ShouldBe(0);
        }

        [Test]
        public void CanSetAPreference()
        {
            var store = new MemoryPreferenceStore();
            store.Set("TestStringPreference", "I am a string");
            store.Count.ShouldBe(1);
        }

        [Test]
        public void CanGetAPreference()
        {
            var key = "SimplePreference";
            var store = new MemoryPreferenceStore();

            store.Set(key, 3);
            store.Count.ShouldBe(1);

            var found = store.TryGet(key, out int result);
            result.ShouldBe(3);
        }

        [Test]
        public void CanSetSamePreferenceTwice ()
        {
            var key = "TestStringPreference";
            var store = new MemoryPreferenceStore();

            store.Set(key, "String1");
            store.Count.ShouldBe(1);

            store.Set(key, "String2");
            store.Count.ShouldBe(1);
        }

        [Test]
        public void CanUpdatePreference ()
        {
            var key = "TestIntPreference";
            var store = new MemoryPreferenceStore();

            store.Set(key, 15);
            store.Count.ShouldBe(1);
            store.TryGet(key, out int result);
            result.ShouldBe(15);

            store.Set(key, 12);
            store.Count.ShouldBe(1);
            store.TryGet(key, out int updatedResult);
            updatedResult.ShouldBe(12);
        }

        [Test]
        public void DefaultValueForMissingPreference()
        {
            var key = "InvalidKey";
            var store = new MemoryPreferenceStore();
            store.Count.ShouldBe(0);

            var found = store.TryGet(key, out bool result);
            found.ShouldBeFalse();
            result.ShouldBeFalse();
        }

        [Test]
        public void DefaultValueForUnsetPreference()
        {
            var key = "DefaultKey";
            var store = new MemoryPreferenceStore();
            store.Set<object>(key, null);
            store.Count.ShouldBe(1);

            var found = store.TryGet(key, out int result);
            found.ShouldBeTrue();
            result.ShouldBe(0);
        }
    }
}