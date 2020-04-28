# Inside cluster curl
while true; do curl demo/api/demo && echo ""; done

# Inside cluster curl to canary
while true; do curl -H "x-demo-environment: canary"  demo/api/demo && echo ""; done

# Outside cluster curl
while true; do curl demo.lin/api/demo && echo ""; done

# Outside cluster curl to canary
while true; do curl demo.lin/api/demo -H "x-demo-environment: canary" && echo ""; done

# Outside cluster curl to prod
while true; do curl demo.lin/api/demo -H "x-demo-environment: prod" && echo ""; done

