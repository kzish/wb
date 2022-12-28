function handleResponse(resp) {
  resp.json().then(runConfig);
}
function runConfig(config) {
  if (config && config.maintenance && config.maintenance.isMaintenance) {
    window.location.replace('maintenance.html');
  }
}
// Detect if user is on IE browser
var isIE = !!window.MSInputMethodContext && !!document.documentMode;

if (isIE) {
  // Create Promise polyfill script tag
  var promiseScript = document.createElement('script');
  promiseScript.type = 'text/javascript';
  promiseScript.src = 'https://cdn.jsdelivr.net/npm/promise-polyfill@8.1.3/dist/polyfill.min.js';

  // Create Fetch polyfill script tag
  var fetchScript = document.createElement('script');
  fetchScript.type = 'text/javascript';
  fetchScript.src = 'https://cdn.jsdelivr.net/npm/whatwg-fetch@3.4.0/dist/fetch.umd.min.js';

  // Add polyfills to head element
  document.head.appendChild(promiseScript);
  document.head.appendChild(fetchScript);
  // Wait for the polyfills to load and run the function.
  setTimeout(function () {
    window.fetch('configuration.json').then(handleResponse);
  }, 1000);
} else {
  fetch('configuration.json').then(handleResponse);
}
