const { ApolloServer } = require('apollo-server');
const { ApolloGateway } = require('@apollo/gateway');

const gateway = new ApolloGateway({
    serviceList: [
      { name: 'droids', url: 'https://localhost:44392' }
    ]
  });
  
  const server = new ApolloServer({ 
      gateway,
      subscriptions: false
     });
  server.listen();
  