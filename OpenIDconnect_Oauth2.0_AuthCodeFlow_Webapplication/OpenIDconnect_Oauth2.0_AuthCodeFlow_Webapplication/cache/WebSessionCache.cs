using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace OpenIDconnect_Oauth2._0_AuthCodeFlow_Webapplication.cache
{
    public class WebSessionCache:TokenCache
    {
        private static ReaderWriterLockSlim SessionLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private string UserObjectID = string.Empty;
        private string CacheID = string.Empty;

        public WebSessionCache(string userID) {
            this.UserObjectID = userID;
            this.CacheID = UserObjectID + "_TokenCache";
            this.AfterAccess = AfterAccessNotification;
            this.BeforeAccess = BeforeAccessNotification;
            Load();
        }

        public void Load() {
            SessionLock.EnterReadLock();
            this.Deserialize((byte[])HttpContext.Current.Session[CacheID]);
            SessionLock.ExitReadLock();
        }

        void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            if (this.HasStateChanged) {
                SessionLock.EnterWriteLock();
                this.HasStateChanged = false;
                HttpContext.Current.Session[CacheID] = this.Serialize();
                SessionLock.EnterWriteLock();
            }
        }
        void BeforeAccessNotification(TokenCacheNotificationArgs args) {
            if (this.HasStateChanged)
            {
                SessionLock.EnterWriteLock();
                HttpContext.Current.Session[CacheID] = this.Serialize();
                SessionLock.EnterWriteLock();
            }
            Load();
        }
    }
}