FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

LABEL "com.github.actions.name"="GitHub Issue Label (Generic)"
LABEL "com.github.actions.description"="This action labels/unlables on a given issue of a given GitHub repository in the most generic way."
LABEL "com.github.actions.icon"="tag"
LABEL "com.github.actions.color"="blue"

LABEL "repository"="http://github.com/justinyoo/github-issue-label-action"
LABEL "homepage"="http://github.com/justinyoo"
LABEL "maintainer"="Justin Yoo <no-reply@justinchronicles.net>"

COPY *.sln .
COPY src/ ./src/

ADD entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

ENTRYPOINT ["/entrypoint.sh"]
