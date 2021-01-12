namespace ManpBLL
{
    public class UserService
    {

        public int UserLogin(string name, string pwd)
        {
            ManpDAL.UserManager user = new ManpDAL.UserManager();

            return user.UserLonin(name, pwd);
        }

        public string UserJosnEdit(int page, int limit, string id, string account, string rid)
        {
            ManpDAL.UserManager user = new ManpDAL.UserManager();
            return user.UserJosnEdit(page, limit, id, account, rid);
        }

        public string UserSelOption()
        {
            ManpDAL.UserManager user = new ManpDAL.UserManager();
            return user.UserSelOptin();
        }

        public int UserSelDel(string allid)
        {
            ManpDAL.UserManager user = new ManpDAL.UserManager();
            return user.UserSelDel(allid);
        }

        public int UserEdit(ManpowerMODEL.UserAddEditInfo user)
        {

            ManpDAL.UserManager user1 = new ManpDAL.UserManager();
            return user1.UserEdit(user);
        }
        public int UserAdd(ManpowerMODEL.UserAddEditInfo user)
        {
            ManpDAL.UserManager user1 = new ManpDAL.UserManager();
            return user1.UserAdd(user);
        }

        public string Repwd(string npwd, int id, string lpwd)
        {
            ManpDAL.UserManager user1 = new ManpDAL.UserManager();
            return user1.Repwd(npwd, id, lpwd);
        }
        public int CheckDuplicate(string uname)
        {
            ManpDAL.UserManager user1 = new ManpDAL.UserManager();
            return user1.CheckDuplicate(uname);
        }
        public int UserReg(string uname, string upwd, int seid, string selsave)
        {
            ManpDAL.UserManager user1 = new ManpDAL.UserManager();
            return user1.UserReg(uname, upwd, seid, selsave);
        }
        public string MibaoList()
        {
            ManpDAL.UserManager user1 = new ManpDAL.UserManager();
            return user1.MibaoList();
        }

        public int Userrecover(string uname, string upwd, int seid, string selsave)
        {
            ManpDAL.UserManager user1 = new ManpDAL.UserManager();
            return user1.Userrecover(uname, upwd, seid, selsave);
        }
    }
}
