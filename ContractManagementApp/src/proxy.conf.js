const PROXY_CONFIG = [
  {
    context: [
      "/CheckCustomer"
    ],

    target: "https://localhost:7215",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
