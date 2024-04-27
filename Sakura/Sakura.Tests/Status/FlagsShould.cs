using FluentAssertions;
using Sakura.Status;

namespace Sakura.Tests.Status;

[TestFixture]
public class FlagsShould
{
    [Test]
    public void Add_Flag_With_Default_Status_Given_Name()
    {
        var flags = new Flags();

        flags.Add("Flag1");

        flags["Flag1"].Should().BeFalse();
    }

    [Test]
    public void Add_Flag_With_Specified_Status()
    {
        var flags = new Flags();

        flags.Add("Flag1", true);

        flags["Flag1"].Should().BeTrue();
    }

    [Test]
    public void Update_Flag_Status_Using_Indexer()
    {
        var flags = new Flags { { "Flag1", false } };

        flags["Flag1"] = true;

        flags["Flag1"].Should().BeTrue();
    }

    [Test]
    public void Add_Flag_With_Specified_Status_Using_Indexer_If_Nonexistent()
    {
        var flags = new Flags();

        flags["Flag1"] = true;

        flags["Flag1"].Should().BeTrue();
    }

    [Test]
    public void Enumerate_Correctly()
    {
        var flags = new Flags
        {
            { "Flag1", true },
            { "Flag2", false }
        };
        
        var enumerator = flags.GetEnumerator();
        var flagNames = new List<string>();
        while (enumerator.MoveNext())
        {
            flagNames.Add(enumerator.Current.Name);
        }

        flagNames.Count.Should().Be(2);
        flagNames.Should().Contain("Flag1");
        flagNames.Should().Contain("Flag2");
    }
}