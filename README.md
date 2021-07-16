# GitHub Issue Label Action #

This action labels and unlables on a specific GitHub issue in the most generic way.


## Inputs ##

* `authToken`: (**required**) GitHub authentication token
* `owner`: (**required**) GitHub repository owner/organisation.
* `repository`: (**required**) GitHub repository.
* `issueId`: (**required**) GitHub issue ID for the PR.
* `labelsToAdd`: Comma delimited list of labels to add to the given issue.
* `labelsToRemove`: Comma delimited list of labels to remove from the given issue.


## Example Usage ##

```yaml
steps:
  name: Labels on issue
  uses: justinyoo/github-issue-label-action@v1
  with:
    authToken: ${{ secrets.GITHUB_TOKEN }}
    owner: <github_username_or_organisation_name>
    repository: <repository_name>
    issueId: '<issue-id>'
    labelsToAdd: 'bug,documentation,duplicate,enhancement,good first issue,help wanted,invalid,question,wontfix'
    labelsToRemove: 'bug,documentation,duplicate,enhancement,good first issue'
```


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work with corresponding tests, please send us a pull request onto our `main` branch for review.


## License ##

**GitHub PR Merge Action** is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2021 [Justin Yoo](https://github.com/justinyoo)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
