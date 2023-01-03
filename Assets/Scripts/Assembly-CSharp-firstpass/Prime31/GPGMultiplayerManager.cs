using System;
using System.Runtime.CompilerServices;

namespace Prime31
{
	public class GPGMultiplayerManager : AbstractManager
	{
		private class GPGRoomUpdateInfo
		{
			public GPGRoom room { get; set; }

			public int statusCode { get; set; }

			public GPGRoomUpdateStatus status
			{
				get
				{
					return (GPGRoomUpdateStatus)statusCode;
				}
			}
		}

		[method: MethodImpl(32)]
		public static event Action<string> onInvitationReceivedEvent;

		[method: MethodImpl(32)]
		public static event Action<string> onInvitationRemovedEvent;

		[method: MethodImpl(32)]
		public static event Action<bool> onWaitingRoomCompletedEvent;

		[method: MethodImpl(32)]
		public static event Action<bool> onInvitationInboxCompletedEvent;

		[method: MethodImpl(32)]
		public static event Action<bool> onInvitePlayersCompletedEvent;

		[method: MethodImpl(32)]
		public static event Action<GPGRoom, GPGRoomUpdateStatus> onJoinedRoomEvent;

		[method: MethodImpl(32)]
		public static event Action onLeftRoomEvent;

		[method: MethodImpl(32)]
		public static event Action<GPGRoom, GPGRoomUpdateStatus> onRoomConnectedEvent;

		[method: MethodImpl(32)]
		public static event Action<GPGRoom, GPGRoomUpdateStatus> onRoomCreatedEvent;

		[method: MethodImpl(32)]
		public static event Action<string, byte[]> onRealTimeMessageReceivedEvent;

		[method: MethodImpl(32)]
		public static event Action onConnectedToRoomEvent;

		[method: MethodImpl(32)]
		public static event Action onDisconnectedFromRoomEvent;

		[method: MethodImpl(32)]
		public static event Action<string> onP2PConnectedEvent;

		[method: MethodImpl(32)]
		public static event Action<string> onP2PDisconnectedEvent;

		[method: MethodImpl(32)]
		public static event Action<string> onPeerDeclinedEvent;

		[method: MethodImpl(32)]
		public static event Action<string> onPeerInvitedToRoomEvent;

		[method: MethodImpl(32)]
		public static event Action<string> onPeerJoinedEvent;

		[method: MethodImpl(32)]
		public static event Action<string> onPeerLeftEvent;

		[method: MethodImpl(32)]
		public static event Action<string> onPeerConnectedEvent;

		[method: MethodImpl(32)]
		public static event Action<string> onPeerDisconnectedEvent;

		[method: MethodImpl(32)]
		public static event Action<GPGRoom> onRoomAutoMatchingEvent;

		[method: MethodImpl(32)]
		public static event Action<GPGRoom> onRoomConnectingEvent;

		static GPGMultiplayerManager()
		{
			AbstractManager.initialize(typeof(GPGMultiplayerManager));
		}

		private void onInvitationReceived(string invitationId)
		{
			GPGMultiplayerManager.onInvitationReceivedEvent.fire(invitationId);
		}

		private void onInvitationRemoved(string invitationId)
		{
			GPGMultiplayerManager.onInvitationRemovedEvent.fire(invitationId);
		}

		private void onWaitingRoomCompleted(string success)
		{
			GPGMultiplayerManager.onWaitingRoomCompletedEvent.fire(success == "1");
		}

		private void onInvitationInboxCompleted(string success)
		{
			GPGMultiplayerManager.onInvitationInboxCompletedEvent.fire(success == "1");
		}

		private void onInvitePlayersCompleted(string success)
		{
			GPGMultiplayerManager.onInvitePlayersCompletedEvent.fire(success == "1");
		}

		private void onJoinedRoom(string json)
		{
			GPGRoomUpdateInfo gPGRoomUpdateInfo = Json.decode<GPGRoomUpdateInfo>(json);
			GPGMultiplayerManager.onJoinedRoomEvent.fire(gPGRoomUpdateInfo.room, gPGRoomUpdateInfo.status);
		}

		private void onLeftRoom(string empty)
		{
			GPGMultiplayerManager.onLeftRoomEvent.fire();
		}

		private void onRoomConnected(string json)
		{
			GPGRoomUpdateInfo gPGRoomUpdateInfo = Json.decode<GPGRoomUpdateInfo>(json);
			GPGMultiplayerManager.onRoomConnectedEvent.fire(gPGRoomUpdateInfo.room, gPGRoomUpdateInfo.status);
		}

		private void onRoomCreated(string json)
		{
			GPGRoomUpdateInfo gPGRoomUpdateInfo = Json.decode<GPGRoomUpdateInfo>(json);
			GPGMultiplayerManager.onRoomCreatedEvent.fire(gPGRoomUpdateInfo.room, gPGRoomUpdateInfo.status);
		}

		public static void onRealTimeMessageReceived(string senderParticipantId, byte[] message)
		{
			if (GPGMultiplayerManager.onRealTimeMessageReceivedEvent != null)
			{
				GPGMultiplayerManager.onRealTimeMessageReceivedEvent(senderParticipantId, message);
			}
		}

		private void onConnectedToRoom(string empty)
		{
			GPGMultiplayerManager.onConnectedToRoomEvent.fire();
		}

		private void onDisconnectedFromRoom(string empty)
		{
			GPGMultiplayerManager.onDisconnectedFromRoomEvent.fire();
		}

		private void onP2PConnected(string participantId)
		{
			GPGMultiplayerManager.onP2PConnectedEvent.fire(participantId);
		}

		private void onP2PDisconnected(string participantId)
		{
			GPGMultiplayerManager.onP2PDisconnectedEvent.fire(participantId);
		}

		private void onPeerDeclined(string id)
		{
			GPGMultiplayerManager.onPeerDeclinedEvent.fire(id);
		}

		private void onPeerInvitedToRoom(string id)
		{
			GPGMultiplayerManager.onPeerInvitedToRoomEvent.fire(id);
		}

		private void onPeerJoined(string id)
		{
			GPGMultiplayerManager.onPeerJoinedEvent.fire(id);
		}

		private void onPeerLeft(string id)
		{
			GPGMultiplayerManager.onPeerLeftEvent.fire(id);
		}

		private void onPeerConnected(string id)
		{
			GPGMultiplayerManager.onPeerConnectedEvent.fire(id);
		}

		private void onPeerDisconnected(string id)
		{
			GPGMultiplayerManager.onPeerDisconnectedEvent.fire(id);
		}

		private void onRoomAutoMatching(string json)
		{
			GPGMultiplayerManager.onRoomAutoMatchingEvent.fire(Json.decode<GPGRoom>(json));
		}

		private void onRoomConnecting(string json)
		{
			GPGMultiplayerManager.onRoomConnectingEvent.fire(Json.decode<GPGRoom>(json));
		}
	}
}
