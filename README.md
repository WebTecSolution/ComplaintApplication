# Complaint Application with IdentityServer4, ElasticSearch, and RabbitMQ

Reposistory having samples of the Rabbit Messeging Queue and Elastic Search. Below is the core logic for the project uploaded.

![](CoreLogic.PNG)

# RabbitMQ
Download the following to Proceed with RabbitMQ:
[Download and install ERLANG Latest version](https://www.erlang.org/downloads)
[Download and install RabbitMQ Latest Version](https://www.rabbitmq.com/download.html)

Default port for the RabbitMQ: http://localhost:15672/
Default Username and Password: guest

Some useful commands just for startups.
1. To Enable Management
```
rabbitmq-plugins enable rabbitmq_management
```
2. Start Server
```
rabbitmqctl start_app
```
3. Stop Server
```
rabbitmqctl stop_app
```
4. Reset Server
```
//warning this is resetting all the queues reset all so becareful about it
rabbitmqctl reset
```
5. Create New User
```
rabbitmqctl add_user [UserName] [Password]
rabbitmqctl add_user Kashif Kashif
```
6. Tags Assign 
```
rabbitmqctrl set_user_tags [UserName] [Role>> Administrator etc]
rabbitmqctrl set_user_tags Kashif administrator
```
7. Setting permissions
```
// ".*"=> means all the permissions
rabbitmqctl set_permissions -p / [UserName] [Read] [Write] [View]
rabbitmqctl set_permissions -p / Kashif ".*" ".*" ".*"
```

# Elasticsearch
[Download Elasticsearch in your system](https://www.elastic.co/downloads/)
Download the following from there
1. Elasticsearch
2. Kibana

## Note: While testing or executing must check RabbitMQ, Elasticsearch server must be runing.


# Instruction for the Execution
1. First execute: ComplaintsApplication.Elasticsearch.ElasticDBSetup 
    1. It will create Elasticsearch => Indices => Types => Documents with Properties
2. Right click on the main solution file and select properties.
3. In Properties select multiple startup projects
4. Then select projects to startup given below: You need to change the value from the dropdown besides the project name in Action column to Start.
    1. ComplaintsApplication.ReadWrite.API
    2. ComplaintsApplication.Transfer.API
