import React, { useEffect, useState } from "react";
import { createAPIEndpoint, ENDPOINTS, BASE_URL } from "../api";
import data from "../system/info.json";
import DynamicTable from "./DynamicTable";

const NewSystemInfo = () => {
  const [serviceSystemInfo, setServiceSystemInfo] = useState(null);

  useEffect(() => {
    createAPIEndpoint(ENDPOINTS.getServiceSystemInfo)
      .fetch()
      .then((res) => {
        setServiceSystemInfo(res.data);
        console.log(res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  }, []);

  return (
    <div>
      {serviceSystemInfo != null && (
        <DynamicTable input={serviceSystemInfo} header={"Service Info.."} />
      )}
      <DynamicTable input={data} header={"Microsite Info.."} />
    </div>
  );
};

export default NewSystemInfo;
