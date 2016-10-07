VERSION 5.00
Begin VB.Form ComStructsVBForm 
   Caption         =   "Form1"
   ClientHeight    =   4560
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6495
   LinkTopic       =   "Form1"
   ScaleHeight     =   4560
   ScaleWidth      =   6495
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   3975
      Left            =   240
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   120
      Width           =   5655
   End
End
Attribute VB_Name = "ComStructsVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Call UseClass
    Call UseStruct
    
    Call TestVB
    
End Sub

Private Sub UseClass()
    'create instance of com object
    Dim comObj As _
        New DniNetStructs.DniNetClassesObj
    'define account object
    Dim account As DniNetStructs.IAccount
    
    'retrieve the account
    Set account = comObj.RetrieveAccount(123)
    Text1.Text = Text1.Text + _
        "RetrieveAccount - " _
        + " AccountId: " + CStr(account.AccountId) _
        + ", Name: " + account.AccountName _
        + ", Balance: " + CStr(account.Balance) _
        + vbCrLf
        
    'update the account balance
    Call comObj.UpdateBalance(account)
    Text1.Text = Text1.Text + _
        "UpdateBalance   - " _
        + " AccountId: " + CStr(account.AccountId) _
        + ", Name: " + account.AccountName _
        + ", Balance: " + CStr(account.Balance) _
        + vbCrLf
    
    'free the COM reference
    Set comObj = Nothing
End Sub

Private Sub UseStruct()
    'create instance of com object that uses structs
    Dim comObj As _
        New DniNetStructs.DniNetStructsObj
    'define account object (struct)
    Dim account As DniNetStructs.AccountStruct
    
    'retrieve the account into the struct
    account = comObj.RetrieveAccount(123)
    Text1.Text = Text1.Text + _
        "RetrieveAccount - " _
        + " AccountId: " + CStr(account.AccountId) _
        + ", Name: " + account.AccountName _
        + ", Balance: " + CStr(account.Balance) _
        + vbCrLf
        
    'update the account balance in the struct
    Call comObj.UpdateBalance(account)
    Text1.Text = Text1.Text + _
        "UpdateBalance   - " _
        + " AccountId: " + CStr(account.AccountId) _
        + ", Name: " + account.AccountName _
        + ", Balance: " + CStr(account.Balance) _
        + vbCrLf
    
    'create our own instance of the struct
    Dim acctStruct As DniNetStructs.AccountStruct
    acctStruct.AccountId = 456
    acctStruct.AccountName = "new account"
    acctStruct.Balance = 100.21
    
    'update the account balance in the struct
    Call comObj.UpdateBalance(acctStruct)
    Text1.Text = Text1.Text + _
        "UpdateBalance   - " _
        + " AccountId: " + CStr(acctStruct.AccountId) _
        + ", Name: " + acctStruct.AccountName _
        + ", Balance: " + CStr(acctStruct.Balance) _
        + vbCrLf
    
    'free the COM reference
    Set comObj = Nothing
End Sub




