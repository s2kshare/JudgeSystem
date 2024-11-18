import HomeDashboard from '../components/HomeDashboard';
import HomeTable from '../components/HomeTable';
import { useUser } from '../contexts/UserContext';

function Home() {
    const { user, updateUser } = useUser();
    return (
        <div className="">
            <HomeDashboard />
            <div className="m-10">
                <HomeTable />
            </div>
        </div>
    );
}

export default Home;
