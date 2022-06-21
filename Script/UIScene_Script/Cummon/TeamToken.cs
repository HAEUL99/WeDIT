using System;
using Photon.Bolt;


public class TeamToken : IProtocolToken
{
    public string RoomName;
    public string HostID;
    public string[] MemberID = new string[5];
    public string Password;
    public int InvitePossibility;
    public int MemberNowIn;
    public int TotalMemberCapacity;

    public bool IsStart;
    public bool IsShutDown;
    public bool IsFinish;


    public void Write(UdpKit.UdpPacket packet)
    {
        packet.WriteString(RoomName);
        packet.WriteString(HostID);
        for (int i = 0; i < 5; i++)
        {
            packet.WriteString(MemberID[i]);
        }
        packet.WriteString(Password);
        packet.WriteInt(InvitePossibility);
        packet.WriteInt(MemberNowIn);
        packet.WriteInt(TotalMemberCapacity);

        packet.WriteBool(IsStart);
        packet.WriteBool(IsShutDown);
        packet.WriteBool(IsFinish);
    }

    public void Read(UdpKit.UdpPacket packet)
    {
        RoomName = packet.ReadString();
        HostID = packet.ReadString();
        for (int i = 0; i < 5; i++)
        {
            MemberID[i] = packet.ReadString();
        }
        Password = packet.ReadString();
        InvitePossibility = packet.ReadInt();
        MemberNowIn = packet.ReadInt();
        TotalMemberCapacity = packet.ReadInt();

        IsStart = packet.ReadBool();
        IsShutDown = packet.ReadBool();
        IsFinish = packet.ReadBool();
    }

    internal void Remove(string playerId)
    {
        throw new NotImplementedException();
    }
}