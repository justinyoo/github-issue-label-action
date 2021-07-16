#!/bin/sh -l

cd /app

dotnet restore
dotnet build src/GitHubActionsLabelIssue.ConsoleApp -c Release
dotnet run --project src/GitHubActionsLabelIssue.ConsoleApp -c Release -- \
    -o "$OWNER" \
    -r "$REPOSITORY" \
    -i "$ISSUE_ID" \
    --labels-add "$LABELS_TO_ADD" \
    --labels-remove "$LABELS_TO_REMOVE"
