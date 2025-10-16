import{LineChart,Line,XAxis,YAxis,Legend,Tooltip,CartesianGrid} from 'recharts';

const data=[
    {month:"jan",sales:4000},
    {month:"feb",sales:3000},
    {month:"mar",sales:5000},
    {month:"apr",sales:4000},
    {month:"may",sales:6000},
    {month:"jun",sales:7000},   
]


function LineCharts(){
    return(
        <div>
        <LineChart width={600} height={400} data={data}>
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="month"/>
            <YAxis/>
            <Tooltip/>
            <Legend/>
            <Line type="monotone" dataKey="sales"/>

         </LineChart>
        </div>
   
    );
    }

export default LineCharts;