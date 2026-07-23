FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

# RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
ENV TZ=Asia/Shanghai

# ========== 【必须加：安装字体库】 ==========
#RUN apt-get update && apt-get install -y libgdiplus libc6-dev
#RUN ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll
# ============================================

COPY . .
ENTRYPOINT ["dotnet", "Host.dll"]
