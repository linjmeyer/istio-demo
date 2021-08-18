# Demo for Istio Canaries 

This project is a demo for Istio canaries and Istio pipelines using Spinnaker.  ([Youtube](https://www.youtube.com/watch?v=kd-L0DYfZjk)).

## Source

* `istio` folder contains the Istio operator, namespace and gateway.  (Install Istio operator via `istioctl` first)
* `scripts` contains curl scripts used for demo
* `spinnaker` contains Spinnaker pipeline definition in JSON
* `spinnaker-config` contains the Spinnaker CRDs, Operator and Spinnaker configuration used to install Spinnaker
* `src` .NET Core projects used during the demo
* `Dockerfile` and `tests.Dockerfile` ASP.NET Core app and .NET Core integration test dockerfiles

