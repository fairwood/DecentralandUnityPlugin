# !/bin/bash
source $HOME/.bash_profile
if [ `echo $DCL_HOME` ];then
	echo "DCL_HOME is $DCL_HOME"
	exit 0
fi
echo "setup DCL_HOME ..."
if [ `which dcl` ];then
	DCL_EXE=`which dcl`
	echo "$DCL_EXE"
	DCL_HOME=`echo "$DCL_EXE"| sed -e 's/bin\/dcl//g'`
	echo "DCL_HOME is $DCL_HOME"
	echo "export DCL_HOME=$DCL_HOME" >> $HOME/.bash_profile
	echo "export PATH=\$PATH:\$DCL_HOME/bin" >> $HOME/.bash_profile
fi
