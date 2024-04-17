import { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = 'https://square6-crm-api.azurewebsites.net/'