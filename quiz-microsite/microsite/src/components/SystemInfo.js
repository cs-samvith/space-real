import React, { useEffect, useState } from "react";
import { createAPIEndpoint, ENDPOINTS, BASE_URL } from "../api";
import data from "../system/info.json";

const SystemInfo = () => {
  // const [systemInfo, setSystemInfo] = useState(null);
  const [serviceSystemInfo, setServiceSystemInfo] = useState(null);

  useEffect(() => {
    createAPIEndpoint(ENDPOINTS.getServiceSystemInfo)
      .fetch()
      .then((res) => {
        setServiceSystemInfo(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  // const getSystemInfo = () => {
  //   fetch("./system/info.json", {
  //     headers: {
  //       "Content-Type": "application/json",
  //       Accept: "application/json",
  //     },
  //   })
  //     .then(function (response) {
  //       return response.json();
  //     })
  //     .then(function (myJson) {
  //       console.log(myJson);
  //       setSystemInfo(myJson);
  //     });
  // };

  // useEffect(() => {
  //   try {
  //     getSystemInfo();
  //   } catch {
  //     console.log("unable to retrive");
  //   }
  // }, []);

  return (
    <div>
      <div>
        <h1>Quiz Microsite</h1>
        {data != null ? (
          <div>
            <table className="table table-striped" aria-labelledby="tabelLabel">
              <thead>
                <tr>
                  <th>ApplicationName</th>
                  <th>DeploymentPlatform</th>
                  <th>DevOpsTool</th>
                  <th>Environment</th>
                  <th>InstanceName</th>
                </tr>
              </thead>
              <tbody>
                {/* <tr>
                  <td>{systemInfo.ApplicationName}</td>
                  <td>{systemInfo.DeploymentPlatform}</td>
                  <td>{systemInfo.DevOpsTool}</td>
                  <td>{systemInfo.Environment}</td>
                  <td>{systemInfo.InstanceName}</td>
                </tr> */}
                <tr>
                  <td>{data.ApplicationName}</td>
                  <td>{data.DeploymentPlatform}</td>
                  <td>{data.DevOpsTool}</td>
                  <td>{data.Environment}</td>
                  <td>{data.InstanceName}</td>
                </tr>
              </tbody>
            </table>
          </div>
        ) : (
          <p>No service info retrieved</p>
        )}
      </div>
      <div>
        <h1>Quiz Service</h1>
        {serviceSystemInfo != null ? (
          <div>
            <table className="table table-striped" aria-labelledby="tabelLabel">
              <thead>
                <tr>
                  <th>ApplicationName</th>
                  <th>DeploymentPlatform</th>
                  <th>DevOpsTool</th>
                  <th>Environment</th>
                  <th>InstanceName</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{serviceSystemInfo.ApplicationName}</td>
                  <td>{serviceSystemInfo.DeploymentPlatform}</td>
                  <td>{serviceSystemInfo.DevOpsTool}</td>
                  <td>{serviceSystemInfo.Environment}</td>
                  <td>{serviceSystemInfo.InstanceName}</td>
                </tr>
              </tbody>
            </table>
          </div>
        ) : (
          <p>No service info retrieved</p>
        )}
      </div>
    </div>
  );
};

export default SystemInfo;
