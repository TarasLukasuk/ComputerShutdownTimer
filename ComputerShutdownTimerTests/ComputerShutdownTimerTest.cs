using ComputerShutdownTimer.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerShutdownTimerTests
{
    [TestClass]
    public class ComputerShutdownTimerTest
    {
        [TestMethod]
        public void IsHex_ValidHexColor_ReturnsTrue()
        {
            string[] hexColors = { "#FFFFFF", "#C2C5CE", "#156D35", "#E338D0", "#9174B6", "#4DCCA7", "#1663D8",
                                   "#D06DCB", "#5876A6", "#EA6CA1", "#9D7889", "#F73694", "#A3FB75", "#42CCF5",
                                   "#9339E9", "#8202A7", "#90DDC5", "#3B36A1", "#C0C026", "#9CB476", "#5F9B03",
                                   "#52F8FD", "#DB5135", "#16232B", "#21BAD1", "#8FCB8F", "#3D1DF7", "#102740",
                                   "#C03E47", "#B93622", "#36CB8F", "#658E2D", "#C8BDB3", "#EB9D4C", "#28E837",
                                   "#6A149C", "#399973", "#7034C2", "#410263", "#CE9B27", "#CCD971", "#17E754",
                                   "#FE83CE", "#290FB8", "#244ED5", "#66B2D4", "#471EEF", "#5B7FE4", "#93F026",
                                   "#2E31E0", "#BC69FD", "#F98BCC", "#3F98D5", "#EB8002", "#1759C5", "#30ED7F",
                                   "#CC2D61", "#78D4A0", "#929BBC", "#85CCAE", "#D85749", "#3CA12C", "#05B737",
                                   "#8CDC1E", "#B8A5A7", "#0A4687", "#A94B8F", "#1BD1FC", "#91C2B3", "#D4380E",
                                   "#21C17A", "#1A062A", "#49B671", "#81D629", "#CF6754", "#FC5131", "#205BB4",
                                   "#C409D1", "#7F4751", "#0E3CCB", "#FA9307", "#E02C92", "#1F3B28", "#1754B9",
                                   "#36BA72", "#3B915A", "#C7BF07", "#81BDE4", "#8A3C91", "#64AE2B", "#5EE905",
                                   "#CD11E2", "#D7D3D3", "#193642", "#8844DF", "#801F56", "#187B69", "#E5C623",
                                   "#0F14DB", "#B4AD24" 
                                 };

            foreach (string item in hexColors)
            {
                Assert.IsTrue(Validator.IsHex(item));
            }
        }
    }
}
