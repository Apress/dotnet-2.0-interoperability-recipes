Attribute VB_Name = "TestVBNet"
Option Explicit

Public Sub TestVB()

    'create instance of com object
    Dim comObj As _
        New DniNetStructsVB.DniNetClassesObj
    'define account object
    Dim account As DniNetStructsVB.IAccount
    
    'retrieve the account
    Set account = comObj.RetrieveAccount(123)
    ComStructsVBForm.Text1.Text = ComStructsVBForm.Text1.Text + _
        "RetrieveAccount - " _
        + " AccountId: " + CStr(account.AccountId) _
        + ", Name: " + account.AccountName _
        + ", Balance: " + CStr(account.GetBalance()) _
        + vbCrLf
        
    'update the account balance
    Call comObj.UpdateBalance(account)
    ComStructsVBForm.Text1.Text = ComStructsVBForm.Text1.Text + _
        "UpdateBalance   - " _
        + " AccountId: " + CStr(account.AccountId) _
        + ", Name: " + account.AccountName _
        + ", Balance: " + CStr(account.GetBalance()) _
        + vbCrLf
    
    'free the COM reference
    Set comObj = Nothing

End Sub
