﻿// Copyright (c) David Pine. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace ProfanityFilter.Services.Tests;

public partial class MatchEvaluatorTests
{
    [Theory]
    [InlineData("Test", "****")]
    public void AsteriskEvaluator_Returns_Expected_Result(string input, string expected)
    {
        var regex = TestRegex();

        var match = regex.Match(input);

        var actual = MatchEvaluators.AsteriskEvaluator.Invoke(match);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Test")]
    public void EmojiEvaluator_Returns_Expected_Result(string input)
    {
        var regex = TestRegex();

        var match = regex.Match(input);

        var actual = MatchEvaluators.EmojiEvaluator.Invoke(match);

        Assert.NotEqual(input, actual);
    }

    [GeneratedRegex("(.+)")]
    private static partial Regex TestRegex();
}
