# !/bin/bash
source $HOME/.bash_profile
PL=()
kill_proc(){
    for v in $PL
        do
            echo "kill pid $v"
            kill $v
        done
}
PL=`ps aux | grep 'dcl start' | grep -v grep | awk '{print $2}'`
kill_proc
PL=`ps aux | grep 'dcl_start' | grep -v grep | awk '{print $2}'`
kill_proc
PL=`ps aux | grep 'decentraland-compiler' | grep -v grep | awk '{print $2}'`
kill_proc
