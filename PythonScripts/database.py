import pyodbc
import uuid

tables = []
local_server = pyodbc.connect('DRIVER={SQL Server};SERVER=DESKTOP-5J1MT1O\SQLEXPRESS;DATABASE=BookCity')
# remote_server = pyodbc.connect('DRIVER={SQL Server};SERVER=ebsepamdbserver.database.windows.net;DATABASE=ebsEPAM_db;UID=foxychmoxy;PWD=ebsepam1!')
with local_server.cursor() as cursor:
    for row in list(cursor.tables())[1:]:
        tables.append(row.table_name)
        if(row.table_name == 'VocalMusic') : break

    for row in cursor.execute("select * from {}".format(tables[0])):
        print(row)
    for row in cursor.execute("select * from {}".format(tables[1])):
        print(row)
    str(uuid.uuid4())