﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MM = SearchJobNet_project.Models.MemberModel;

namespace SearchJobNet_project.Models.MemberModel
{
    public class Member
    {
        #region 會員功能(註冊/登入/忘記密碼)

        // 新增會員 [ 會員model的attr. 皆為填入項目 ]
        public string registerMember(MM.MemberModel rMember)
        {
            #region [做DB連線 以及 執行DB處理]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 放入 UserID的資料
            string doDB = bsc.ActionDB(
                            string.Format(
                            @"INSERT INTO [Account] (USER_ID,USERNAME,PASSWORD,RE_TIME)
                              VALUES('{0}','{1}','{2}','{3}');"
                              , rMember.User_ID, rMember.UserName, rMember.PassWord
                              , rMember.Re_Time)
                            );

            // 如果 doDB為"success" ,代表DB連線成功 ,反之失敗
            if (doDB != "success")
            {
                return "DB處理錯誤";
            }

            #endregion

            #region[檢查DB內容]

            // 查看是否新增成功
            MemberModel cm = this.memberData(rMember.User_ID);

            // 檢查MemberModel
            if ((rMember.User_ID  == cm.User_ID)&&
                (rMember.UserName == cm.UserName)&&
                (rMember.PassWord == cm.PassWord)&&
                (rMember.Re_Time  == cm.Re_Time)
               )
            {
                return "insert success!";
            }
            else
            {
                return "insert error!";
            }

            #endregion

        }

        // 會員功能 登入 [ 會員model的attr. 皆為填入項目 ]
        public string loginMember(MM.MemberModel lMember)
        {
            MemberModel mm = this.memberData(lMember.User_ID);

            // 檢查MemberModel
            if ((lMember.User_ID  == mm.User_ID) &&
                (lMember.UserName == mm.UserName) &&
                (lMember.PassWord == mm.PassWord)
               )
            {
                return "login success!";
            }
            else
            {
                return "login error!";
            }
        }

        // 瀏覽會員DB資料
        public MM.MemberModel memberData(string user_ID)
        {
            MM.MemberModel bMemberModel = new MM.MemberModel();

            #region [做DB連線 以及 取出DB資料]

            // 建立DB連線
            Tools.DBConnection bsc = new Tools.DBConnection();

            // 取出 會員資料
            DataTable dt = bsc.ReadDB(
                            string.Format(
                            @"SELECT *
                              FROM [Account] AS A
                              WHERE 1=1
                              AND A.USER_ID = '{0}'"
                              , user_ID)
                            );

            // 將DataTable的資料轉換為model
            bMemberModel.User_ID  = dt.Rows[0][0].ToString();
            bMemberModel.UserName = dt.Rows[0][1].ToString();
            bMemberModel.PassWord = dt.Rows[0][2].ToString();
            bMemberModel.Re_Time  = dt.Rows[0][3].ToString();

            return bMemberModel;

            #endregion

        }

        #region[暫時先沒有忘記密碼功能]
        // 會員功能 忘記密碼
        public string forgetMember(int step, string memberID, string answer)
        {
            // step == 0 , 進行 傳入memberID 回傳問題 階段. (此時answer = "")
            // step == 1 , 進行 驗證答案是否正確 回傳密碼或驗證錯誤 階段

            if (step == 0)
            {
                // SQL指令 撈出memberID的問題,並回傳問題
                return "Question";
            }
            else if (step == 1)
            {
                // 收到答案,比對答案是不是一樣
                // 不一樣狀況 return "the answer of question is wrong!";
                // else return 密碼
                return "password";
            }
            else
            {
                return "input wrong parameter";
            }

        }
        #endregion
        
        #endregion
    }
}