while true; do curl demo/api/demo && echo ""; done

while true; do curl -H "x-demo-environment: canary"  demo/api/demo && echo ""; done

