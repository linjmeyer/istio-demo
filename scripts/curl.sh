# Inside cluster curl
while true; do curl demo/api/demo && echo ""; done

# Inside cluster curl to canary
while true; do curl -H "x-demo-environment: canary"  demo/api/demo && echo ""; done

# Outside cluster curl
while true; do printf "\n Routing dynamically: \n" && curl demo.lin/api/demo; done

# Outside cluster curl to canary
while true; do printf "\n Routing to canary... \n" && curl demo.lin/api/demo -H "x-demo-environment: canary"; done

# Outside cluster curl to prod
while true; do printf "\n Routing to prod... \n" && curl demo.lin/api/demo -H "x-demo-environment: prod"; done

