import "./DynamicTable.css";

function DynamicTable(props) {
  const input = props.input;
  const header = props.header;
  const column = Object.keys(input[0]);

  // get table heading data
  const ThData = () => {
    return column?.map((data) => {
      return <th key={data}>{data}</th>;
    });
  };

  // get table row data
  const tdData = () => {
    return input.map((data, index) => {
      return (
        <tr key={index}>
          {column?.map((v) => {
            return <td key={v}>{data[v]}</td>;
          })}
        </tr>
      );
    });
  };

  return (
    <div className="center">
      <h1>{header}</h1>
      <table className="table">
        <thead>
          <tr>{ThData()}</tr>
        </thead>
        <tbody>{tdData()}</tbody>
      </table>
    </div>
  );
}

export default DynamicTable;
