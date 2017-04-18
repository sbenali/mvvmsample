

param([string]$projDir, [string]$brand)

#only for dbg
$projDir = "C:\Users\samir\Documents\Visual Studio 2015\Projects\MVVMSampleApplication\MVVMSampleApplication\MVVMSampleApplication.csproj"
$brand = "DBG-BRAND-A"

Write-Host "*** PARAM ProjDir = $projDir ******"
Write-Host "*** PARAM Brand = $brand *****"



#load the proj file as an xml payload
[xml] $prjXml = Get-Content -Path $projDir
$ns = new-object Xml.XmlNamespaceManager $prjXml.NameTable
$ns.AddNamespace("msb", "http://schemas.microsoft.com/developer/msbuild/2003")


#first check if we have already a property group for the application icon
#change to xpath
function GetAppIconName(){
    
    $i = $prjXml.SelectNodes("//msb:Project//msb:PropertyGroup//msb:ApplicationIcon", $ns)
    if($i.Count -eq 1){
        if($i[0].InnerText -eq ""){
            Write-Host "Found empty icon i.e. default used"
        }else{
            return $i[0].Value
        }
    }
    return ""

}



$appIconName=GetAppIconName
if($appIconName -ne "" -or $null){    
    #found the icon, check its name
    Write-Host "Found Application Icon with Name: $appIconName"
}else{
        
    Write-Host "Application Icon has not been set"
}


