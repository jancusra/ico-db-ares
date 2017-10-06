using ICO.Core.Entities;

namespace ICO.Services.IcoServices
{
    public interface IIcoService
    {
        Data GetDataByIcoFromDb(int ico);
        Zaznam GetDataByIcoFromARES(int ico);
    }
}
