#! /usr/bin/env sh

set -e

echo "Starting SSH ..."
/usr/sbin/sshd 

# datenow=$(date "+%F-%H-%M-%S")
# uniqueid="==========$(hostname)=====$datenow====="
# echo $uniqueid
# sleep 10

# instanceID=""
# count=1
# while [ -z "$instanceID" ]
# do
#   instanceID=$(grep -R $uniqueid /home/LogFiles/  | cut -d'_' -f4)
#   if [ -z "$instanceID" ]; then
#     echo 'sleeping'
#     sleep 5
#     count=$count+1
#   else
#     echo 'got instance id'
#     echo $instanceID
#     break
#   fi
#   if [ $count == 5 ]; then
#     echo 'done attempts No luck'
#   break
#   fi
# done

# echo 'Done Reading'
# echo $instanceID

echo "Starting app ..."
dotnet Quiz.Service.dll $instanceID