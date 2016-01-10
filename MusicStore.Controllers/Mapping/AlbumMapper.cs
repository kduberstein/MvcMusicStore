#region Using Directives

using AutoMapper;
using MusicStore.Controllers.ViewModels.Admin.Album;
using MusicStore.Services.Messaging.AlbumService;

#endregion

namespace MusicStore.Controllers.Mapping
{
    public static class AlbumMapper
    {
        public static CreateAlbumRequest ConvertToCreateAlbumRequest(this CreateAlbumViewModel model)
        {
            return Mapper.Map<CreateAlbumViewModel, CreateAlbumRequest>(model);
        }

        public static EditAlbumViewModel ConvertToEditAlbumViewModel(this GetAlbumResponse response)
        {
            return Mapper.Map<GetAlbumResponse, EditAlbumViewModel>(response);
        }

        public static EditAlbumRequest ConvertToEditAlbumRequest(this EditAlbumViewModel model)
        {
            return Mapper.Map<EditAlbumViewModel, EditAlbumRequest>(model);
        }
    }
}