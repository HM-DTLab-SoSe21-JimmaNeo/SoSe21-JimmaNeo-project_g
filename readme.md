# Readme ALEXANDRIA

This Project contains the webapp for the learningplattform ALEXANDRIA
frontend and backend

# 1 PressRelease

# 2 Description

# 3 Software architecture

The software is contains the frontend in the client part, the backend in the server part.
SEIIApp.Server.Test has no use, those tests might not work properly.
SEIIApp.Shared contains all the DTOs you need.

We don't use any special frameworks or anthing like it, the backend works properly as long as you don't change anything, due to the not perfect implementation of the database.

Now to the IMPORTANT stuff you need to know when you want to continue the development of the app:

We weren't able to implement cookies, therefore the [BiscuitService](SEIIApp\Client\Services\BiscuitService.cs) exists.
This just pretends to be a cookie, so pls replace this with something working, as for now this causes the page to crash during a reload.

The backend contains the UltimateChapterElementDefinitionDto, this is usefull to use the same endpoint for all ChapterElementTypes, pls dont use this in the frontend.

You should be able to start this by simply choosing SEIIApp.Server and start this run configuration, no further adjustments needed.

# 4 Team and contact

# 5 Attachments
