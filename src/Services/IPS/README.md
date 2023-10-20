# IPS Identity Provider

[![License](https://img.shields.io/github/license/parusrx/ips-identity-provider?logo=apache&style=flat-square&color=blue)](LICENSE)
[![Build](https://github.com/parusrx/ips-identity-provider/actions/workflows/build.yml/badge.svg)](https://github.com/parusrx/ips-identity-provider/actions/workflows/build.yml)

This is an identity provider service for the integration subsystem of application subsystem integration (IPS) used for connections to the Unified Public Health Information System (EGISZ).

## Getting started

### Prerequisites

To run the application you need:

- [Docker](https://www.docker.com/)

### Running the application on Docker

- For example, you can run the application with the following command: 
```
$ docker run -d \ 
        --name ips-identity-provider -p 80:80 \ 
        -e Jwt__Auth__Subject=mysubject \ 
        -e Jwt__Auth__Audience=https://ips.test.egisz.rosminzdrav.ru \ 
        -e Jwt__Auth__TokenLifetime=0.00:05:00 \ 
        -e Jwt__Certificate__Path=/usr/src/cert.pfx \ 
        -e Jwt__Certificate__Password=mycertificatepassword \ 
        -v /home/cert:/usr/src \ 
        parusrx/ips-identity-provider
```

- The application will be available at http://localhost:80

### Configuration

The application can be configured using environment variables:

| Environment variable | Description | Default value |
| --- | --- | --- |
| Jwt__Auth__Subject | The subject of the JWT token | |
| Jwt__Auth__Audience | The audience of the JWT token | |
| Jwt__Auth__TokenLifetime | The lifetime of the JWT token | 0.00:05:00 |
| Jwt__Certificate__Path | The path to the certificate | |
| Jwt__Certificate__Password | The password of the certificate | |


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
