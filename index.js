const { ApolloServer } = require('apollo-server');
const { ApolloGateway } = require('@apollo/gateway');

const gateway = new ApolloGateway({
    serviceList: [
      { name: 'droids', url: 'http://localhost:5000/graphql' }
    ]
  });
  
  const server = new ApolloServer({ 
      gateway,
      subscriptions: false
     });
  server.listen();
  