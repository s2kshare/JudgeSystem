function HomeUserStats() {
    return (
        <div className="stats md:stats-vertical stats-horizontal lg:stats-horizontal shadow">
            <div className="stat">
                <div className="stat-title">Labs Completed</div>
                <div className="stat-value">0/40</div>
                <div className="stat-desc">Jan 1st - Feb 1st</div>
            </div>

            <div className="stat">
                <div className="stat-title">Lab Errors</div>
                <div className="stat-value">4,200</div>
                <div className="stat-desc">↗︎ 400 (22%)</div>
            </div>

            <div className="stat">
                <div className="stat-title">Lab Attempts</div>
                <div className="stat-value">1,200</div>
                <div className="stat-desc">↘︎ 90 (14%)</div>
            </div>
        </div>
    );
}

export default HomeUserStats;
