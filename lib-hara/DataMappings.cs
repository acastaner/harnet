using Harnet.Dto;
using Harnet.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Harnet
{
    public static class DataMappings
    {
        // TODO
        public static RootObject FromDto(this RootObjectDto rootObjectDto)
        {
            return new RootObject
            {
                Log = rootObjectDto.Log.FromDto()
            };
        }
        
        public static Log FromDto(this LogDto logDto)
        {
            return new Log
            {
                Version = float.Parse(logDto.version, CultureInfo.InvariantCulture.NumberFormat),
                Creator = logDto.creator.FromDto(),
                Pages = PageDtoListToPageList(logDto.pages),
                Entries = EntryDtoListToEntryList(logDto.entries),
                Browser = (logDto.browser != null) ? logDto.browser.FromDto() : null,
                Comment = logDto.comment
            };
        }

        public static Browser FromDto(this BrowserDto browserDto)
        {
            return new Browser
            {
                Name = browserDto.name,
                Version = float.Parse(browserDto.version, CultureInfo.InvariantCulture.NumberFormat),
                Comment = browserDto.comment
            };            
        }

        public static Creator FromDto(this CreatorDto creatorDto)
        {
            return new Creator
            {
                Name = creatorDto.name,
                Version = float.Parse(creatorDto.version, CultureInfo.InvariantCulture.NumberFormat),
                Comment = creatorDto.comment
            };
        }

        public static PageTimings FromDto(this PageTimingsDto pageTimingsDto)
        {
            return new PageTimings
            {
                OnContentLoad = pageTimingsDto.onContentLoad,
                OnLoad = pageTimingsDto.onLoad,
                Comment = pageTimingsDto.comment
            };
        }

        public static Page FromDto(this PageDto pageDto)
        {
            return new Page
            {
                StartedDateTime = StringDateToDateTime(pageDto.startedDateTime),
                Id = pageDto.id,
                Title = pageDto.title,
                PageTimings = pageDto.pageTimings.FromDto(),
                Comment = pageDto.comment
            };
        }

        public static PostData FromDto(this PostDataDto postDataDto)
        {
            List<Param> paramList = new List<Param>();
            foreach (ParamDto paramDto in postDataDto.@params)
            {
                paramList.Add(paramDto.FromDto());
            }
            return new PostData()
            {
                MimeType = postDataDto.mimeType,
                Text = postDataDto.text,
                Comment = postDataDto.comment,
                Params = paramList
            };
        }

        public static Param FromDto(this ParamDto paramDto)
        {
            return new Param()
            {
                Name = paramDto.name,
                Value = paramDto.value,
                FileName = paramDto.filename,
                ContentType = paramDto.contenttype,
                Comment = paramDto.comment
            }
        }

        public static Request FromDto(this RequestDto requestDto)
        {
            return new Request
            {
                Method = requestDto.method,
                Url = requestDto.url,
                HttpVersion = requestDto.httpVersion,
                //Headers = ObjectListToStringList(requestDto.headers),
                Headers = HeaderListToDictionary(requestDto.headers),
                QueryStrings = ObjectListToStringList(requestDto.queryString),
                Cookies = ObjectListToStringList(requestDto.cookies),
                HeaderSize = requestDto.headersSize,
                BodySize = requestDto.bodySize,
                PostData = (requestDto.postData != null) ? requestDto.postData.FromDto() : null,
                Comment = requestDto.comment
            };
        }

        public static Content FromDto(this ContentDto contentDto)
        {
            return new Content
            {
                Size = contentDto.size,
                MimeType = contentDto.mimeType,
                Compression = contentDto.compression,
                Text = contentDto.text,
                Comment = contentDto.comment
            };
        }
        
        public static Response FromDto(this ResponseDto responseDto)
        {
            return new Response
            {
                Status = responseDto.status,
                StatusText = responseDto.statusText,
                HttpVersion = responseDto.httpVersion,
                Headers = ObjectListToStringList(responseDto.headers),
                Cookies = ObjectListToStringList(responseDto.cookies),
                Content = responseDto.content.FromDto(),
                RedirectUrl = responseDto.redirectURL,
                HeadersSize = responseDto.headersSize,
                BodySize = responseDto.bodySize,
                Comment = responseDto.comment
            };
        }

        public static BeforeRequest FromDto(this BeforeRequestDto beforeRequestDto)
        {
            return new BeforeRequest
            {
                Expires = StringDateToDateTime(beforeRequestDto.expires),
                LastAccess = StringDateToDateTime(beforeRequestDto.lastaccess),
                ETag = beforeRequestDto.etag,
                HitCount = beforeRequestDto.hitcount,
                Comment = beforeRequestDto.comment
            };
        }

        public static AfterRequest FromDto(this AfterRequestDto afterRequestDto)
        {
            return new AfterRequest
            {
                Expires = StringDateToDateTime(afterRequestDto.expires),
                LastAccess = StringDateToDateTime(afterRequestDto.lastaccess),
                ETag = afterRequestDto.etag,
                HitCount = afterRequestDto.hitcount,
                Comment = afterRequestDto.comment
            };
        }

        public static Cache FromDto(this CacheDto cacheDto)
        {
            return new Cache
            {
                BeforeRequest = (cacheDto.beforerequest != null) ? cacheDto.beforerequest.FromDto() : null,
                AfterRequest = (cacheDto.afterrequest != null) ? cacheDto.afterrequest.FromDto() : null,
                Comment = cacheDto.comment
            };
        }

        public static Timings FromDto(this TimingsDto timingsDto)
        {
            return new Timings
            {
                Blocked = timingsDto.blocked,
                Dns = timingsDto.dns,
                Connect = timingsDto.connect,
                Send = timingsDto.send,
                Wait = timingsDto.wait,
                Receive = timingsDto.receive,
                Ssl = timingsDto.ssl,
                Comment = timingsDto.comment
            };
        }
        
        public static Entry FromDto(this EntryDto entryDto)
        {
            return new Entry
            {
                PageRef = entryDto.pageref,
                StartedDateTime = StringDateToDateTime(entryDto.startedDateTime),
                Request = entryDto.request.FromDto(),
                Response = entryDto.response.FromDto(),
                Cache = (entryDto.cache != null) ? entryDto.cache.FromDto() : null,
                Timings = entryDto.timings.FromDto(),
                Connection = entryDto.connection
            };
        }

        private static DateTime StringDateToDateTime(string isoTime)
        {
            try
            {
                return DateTime.Parse(isoTime);
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing date \"" + isoTime + "\" : " + ex.Message);
            }
        }

        private static Dictionary<string, string> HeaderListToDictionary(List<object> headers)
        {
            Dictionary<string, string> hd = new Dictionary<string, string>();
            // TODO something faster could probably be done
            foreach (object header in headers)
            {
                var jobj = (JObject)JsonConvert.DeserializeObject(header.ToString());
                hd.Add(jobj["name"].ToString(), jobj["value"].ToString());
                
            }
            return hd;
        }

        private static List<string> ObjectListToStringList(List<object> objects)
        {
            List<string> strings = new List<string>();
            foreach (object o in objects)
            {
                strings.Add(o.ToString());
            }
            return strings;
        }

        private static List<Entry> EntryDtoListToEntryList(List<EntryDto> dtoList)
        {
            List<Entry> entries = new List<Entry>();
            foreach (EntryDto dto in dtoList)
            {
                entries.Add(dto.FromDto());
            }
            return entries;
        }

        private static List<Page> PageDtoListToPageList(List<PageDto> dtoList)
        {
            List<Page> pages = new List<Page>();
            foreach (PageDto dto in dtoList)
            {
                pages.Add(dto.FromDto());
            }
            return pages;
        }
    }
}