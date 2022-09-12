using FluentAssertions;

namespace MartianRobotsSolver.Tests
{
    public class UnitTestMarsSolver
    {
        [Fact]
        public async Task Sample_Solver_Test()
        {
            var input = await File.ReadAllTextAsync("sample_input.txt");
            var result = new MarsSolver().Process(input);
            var expectedOutput = await File.ReadAllTextAsync("sample_output.txt");
            result.Output.Should().Be(expectedOutput);
        }

        [Fact]
        public async Task Second_Robot_Sense_The_Scent()
        {
            var input = await File.ReadAllTextAsync("sample_scent_input.txt");
            var result = new MarsSolver().Process(input);
            var expectedOutput = await File.ReadAllTextAsync("sample_scent_output.txt");
            result.Output.Should().Be(expectedOutput);
        }
    }
}