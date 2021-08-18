# Demo for Istio Canaries 

This project is a demo for Istio canaries and Istio pipelines using Spinnaker.  ([Youtube](https://www.youtube.com/watch?v=kd-L0DYfZjk)).

## Source

* `istio` folder contains the Istio operator, namespace and gateway.  (Install Istio operator via `istioctl` first)
* `scripts` contains a deployment and configmap with scripts for demo
* `spinnaker` contains Spinnaker pipeline definition in JSON
* `spinnaker-config` contains the Spinnaker CRDs, Operator and Spinnaker configuration used to install Spinnaker
* `src` .NET Core projects used during the demo
* `Dockerfile` and `tests.Dockerfile` ASP.NET Core app and .NET Core integration test dockerfiles

## Demo Setup Instructions

### 1. Port forward Spinnaker

Port forward Spinnaker's `spin-gate` on `8084` and `spin-deck` on `9000`.  I use [derailed/k9s](https://github.com/derailed/k9s) for this.  Open [http://localhost:9000](http://localhost:9000) to view Spinnaker.

### 2. Create App and Pipeline

Create a new application in Spinnaker, and a new pipeline.  Edit the pipeline as Json (top right drop down) and paste in [spinnaker/pipeline.json](spinnaker/pipeline.json).  Save.

## Demo Instructions

(Port forward Spinnaker if not already done)

### 