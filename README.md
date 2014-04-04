1. The project is using wcf json restful service, so from client side we only use html/javascript/jquery to consume the data (json format) provided by the service;</p>

2. The database schema/data can installed by the "install.sql", it will create tables, indexes, foreign keys, data. If you use different database name(default is "demo"), please update the connection string in web.config;

3. The data access layer I used the sql to link;

4. It used couchbase (I choosed "memcached" mode) as cache. Couchbase is high performance & scalable distributed database server. Please check their website for more informaiton. So mostly we only access to MS sql server database for 1st time data request;

5. We can flush cache when updating/feeding currency rate data into the ms sql server. It can be done via SSIS, window service etc. If you don't want to use the cache, just set the "allowCache" to "0" in web.config;

The sample is not from real project. I just wrote it for a demo for you, there are places need to be enhanced. But we can get inspried from the practical sample codes. I hope you like and enjoy it. Any questions feel free to email me via desertwang@gmail.com. Thank you!
