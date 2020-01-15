import pyodbc

tables = []
local_server = pyodbc.connect('DRIVER={SQL Server};SERVER=DESKTOP-5J1MT1O\SQLEXPRESS;DATABASE=BookCity;Trusted_Connection=yes', autocommit=True)
remote_server = pyodbc.connect('DRIVER={SQL Server};SERVER=ebsepamdbserver.database.windows.net;DATABASE=ebsEPAM_db;UID=foxychmoxy;PWD=ebsepam1!',autocommit=True)
with local_server.cursor() as l_cursor:
    for row in list(l_cursor.tables())[1:]:
        tables.append(row.table_name)
        if(row.table_name == 'VocalMusic') : break

    with remote_server.cursor() as r_cursor:
        sql = """
            INSERT BcBooks
               (Title,Author,Description,Price,Rate,Publisher,PublishYear,
               Code,Pages,Cover,Size,Thickness,Weight,Image,GenreId)
             VALUES
               (N'{}', N'{}', N'{}', N'{}', N'{}', N'{}', N'{}',
               N'{}', N'{}', N'{}', N'{}', N'{}', N'{}', N'{}', {})
            """
        for i in range(len(tables)):
            for row in l_cursor.execute("select * from {}".format(tables[i])):
                try:
                    r_cursor.execute(sql.format(row.Title,row.Author,row.Description,row.Price,row.Rate,row.Publisher,row.PublishYear,row.Code,row.Pages,row.Cover,row.Size,row.Thickness,row.Weight,row.Image,i+1))
                    print("{} - success".format(row.Title))
                except:
                    print("{} - failed".format(row.Title))