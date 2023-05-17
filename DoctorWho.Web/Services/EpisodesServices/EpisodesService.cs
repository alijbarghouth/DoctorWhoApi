﻿using DoctorWho.Db.Reopsitories.EpisodesRepository;
using DoctorWho.Web.DTOs.EpisodeDTOs;
using Mapster;

namespace DoctorWho.Web.Services.EpisodesServices;

public class EpisodesService : IEpisodesService
{
    private readonly IEpisodesRepository _episodesRepository;

    public EpisodesService(IEpisodesRepository episodesRepository)
    {
        _episodesRepository = episodesRepository;
    }

    public async Task<List<GetEpisodes>> GetAllEpisodesAsync()
    {
        return (await _episodesRepository.GetAllEpisodesAsync())
            .Adapt<List<GetEpisodes>>();
    }
}