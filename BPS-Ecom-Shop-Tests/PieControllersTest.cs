using BPS_Ecom_Shop.Controllers;
using BPS_Ecom_Shop_Tests.Mocks;

namespace BPS_Ecom_Shop_Tests
{
    public class PieControllersTest
    {
        [Fact]
        public void Pielist_EmptyList_ReturnAllPielist()
        {
            var mockpieRepository = RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var controller = new PieController(mockpieRepository.Object, mockCategoryRepository.Object);
            var result = controller.Index();
        }

        [Fact]
        public void PieList_ThreeItems_ReturnThreeItems()
        {
            var mockPieRepository = RepositoryMocks.GetPieRepository();
        }
    }
}
