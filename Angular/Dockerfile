FROM node:14-alpine AS build
WORKDIR /usr/src/app
COPY package.json ./
RUN npm install
RUN npm audit fix --force 
COPY . .
RUN npm run build

FROM nginx:1.18.0-alpine
COPY --from=build /usr/src/app/dist/NasaAPI /usr/share/nginx/html