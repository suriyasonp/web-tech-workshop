'use strict';

const entries = [
  ['README.md', 'Overview'],
  ['lab-00-environment.md', '00 / Environment Check'],
  ['lab-01-git-github.md', '01 / Git and GitHub'],
  ['lab-02-minimal-api.md', '02 / .NET Minimal API'],
  ['lab-03-first-endpoint.md', '03 / First Task Endpoint'],
  ['lab-04-task-crud.md', '04 / Task CRUD'],
  ['lab-05-ef-core.md', '05 / EF Core and SQLite'],
  ['lab-06-validation.md', '06 / Validation and Errors'],
  ['lab-07-authentication.md', '07 / Authentication'],
  ['lab-08-unit-testing.md', '08 / Backend Testing'],
  ['lab-09-vue-setup.md', '09 / Vue and TypeScript'],
  ['lab-10-layout-routing.md', '10 / Layout and Routing'],
  ['lab-11-axios.md', '11 / Axios Integration'],
  ['lab-12-login.md', '12 / Frontend Login'],
  ['lab-13-task-management.md', '13 / Task Management UI'],
  ['lab-14-final-integration.md', '14 / Final Integration'],
  ['implementation-map.md', 'Implementation Map'],
];
const article = document.querySelector('#article');
const toc = document.querySelector('#toc');
const repositorySource = 'https://github.com/suriyasonp/web-tech-workshop/blob/main/';
const pageLink = (file) => `?lab=${encodeURIComponent(file)}`;
function link(text, href) {
  const element = document.createElement('a');
  element.textContent = text;
  element.href = href;
  return element;
}
const requested = new URLSearchParams(location.search).get('lab') || 'README.md';
const selected = entries.findIndex(([file]) => file === requested);
const labs = document.querySelector('#labs');
entries.forEach(([file, title], index) => {
  const group = {0: 'START HERE', 1: 'DAY 1 / BACKEND', 10: 'DAY 2 / FRONTEND', 16: 'REFERENCE'}[index];
  if (group) {
    const heading = document.createElement('h2');
    heading.textContent = group;
    labs.append(heading);
  }
  const item = link(title, pageLink(file));
  if (index === selected) item.setAttribute('aria-current', 'page');
  labs.append(item);
});
document.querySelector('#search').addEventListener('input', (event) => {
  const query = event.target.value.trim().toLowerCase();
  labs.querySelectorAll('a').forEach((item) => { item.hidden = !item.textContent.toLowerCase().includes(query); });
});

function scrollToHeading() {
  let id;
  try { id = decodeURIComponent(location.hash.slice(1)); } catch { return; }
  if (id) document.getElementById(id)?.scrollIntoView();
}
window.addEventListener('hashchange', scrollToHeading);

async function render() {
  try {
    if (selected < 0) throw new Error('Unknown lab. Choose a page from the lab library.');
    if (location.protocol === 'file:') throw new Error('Open this reader through a web server. From the repository root, run: python -m http.server 8000, then visit http://localhost:8000/student/labs/');
    if (!window.marked || !window.DOMPurify) throw new Error('The Markdown renderer could not load. Check your internet connection and reload this page.');
    const response = await fetch(requested);
    if (!response.ok) throw new Error(`Unable to load this lab (HTTP ${response.status}).`);
    article.innerHTML = DOMPurify.sanitize(marked.parse(await response.text()));
    document.title = `${entries[selected][1]} | Workshop`;
    document.querySelector('#source').href = requested;
    document.querySelector('#position').textContent = entries[selected][1];
    // Match GitHub-style heading anchors and disambiguate repeated headings.
    const used = new Set();
    article.querySelectorAll('h1,h2,h3,h4,h5,h6').forEach((heading) => {
      const base = heading.textContent.toLowerCase().replace(/[^\p{L}\p{N}\p{M}\s_-]/gu, '').replace(/\s/g, '-');
      let id = base;
      let suffix = 0;
      while (used.has(id) || document.getElementById(id)) id = `${base}-${++suffix}`;
      used.add(id);
      heading.id = id;
      const item = link(heading.textContent, `${pageLink(requested)}#${encodeURIComponent(id)}`);
      if (Number(heading.tagName.slice(1)) > 2) item.className = 'sub';
      toc.append(item);
    });
    article.querySelectorAll('a[href]').forEach((anchor) => {
      const href = anchor.getAttribute('href');
      const target = new URL(href, repositorySource + `student/labs/${requested}`);
      const entry = entries.find(([file]) => target.pathname === new URL(file, repositorySource + 'student/labs/').pathname);
      if (entry) anchor.href = pageLink(entry[0]) + target.hash;
      else if (!href.startsWith('#') && target.origin === 'https://github.com') {
        // Pages contains only the reader; other workshop references stay usable on GitHub.
        anchor.href = target.href;
      }
    });
    const pagination = document.querySelector('#pagination');
    if (selected > 0) pagination.append(link(`Previous: ${entries[selected - 1][1]}`, pageLink(entries[selected - 1][0])));
    if (selected < entries.length - 1) pagination.append(link(`Next: ${entries[selected + 1][1]}`, pageLink(entries[selected + 1][0])));
    scrollToHeading();
  } catch (error) {
    article.replaceChildren();
    const message = document.createElement('p');
    message.className = 'error';
    message.textContent = error.message;
    article.append(message);
  }
}
render();
