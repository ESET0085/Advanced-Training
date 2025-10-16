import{BarChart,Bar,XAxis,YAxis,Legend,Tooltip,CartesianGrid} from "recharts";

const data=[
    {month:"jan",sales:4000},
    {month:"feb",sales:3000},
    {month:"mar",sales:5000},
    {month:"apr",sales:4000},
    {month:"may",sales:6000},
    {month:"jun",sales:7000},   



]

function BarCharts(){
    return(
        <>
        <BarChart width={600} height={400} data={data}>
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="month"/>
            <YAxis dataKey="sales"/>
            <Tooltip/>
            <Legend/>
            <Bar dataKey="sales" fill="#8884d8"/>
        </BarChart>
        </>
    );
    }

export default BarCharts;



