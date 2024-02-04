﻿using FastEndpoints;
using MediatR;
using SuperNote.Application.Notes.GetNote;
using SuperNote.WebApi.Endpoints.Notes.Models;

namespace SuperNote.WebApi.Endpoints.Notes;

public class GetById(IMediator mediator) 
    : Endpoint<GetNoteRequest, NoteDto>
{
    public override void Configure()
    {
        Get(ApiRoutes.Notes.GetById);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetNoteRequest req, CancellationToken ct)
    {
        var note = await mediator.Send(new GetNoteQuery(req.NoteId), ct);
        await SendOkAsync(note, ct);
    }
}